# CStudio 현재 구현 이해

## 목적

이 문서는 `cstudio` 저장소를 빠르게 이해하기 위한 현재 구현 기준 요약이다.

기존의 `ROADMAP`, `ARCHITECTURE`, 스프린트 문서는 방향과 이력을 설명한다. 이 문서는 그 위에 현재 코드가 실제로 어떤 구조로 조립되어 있는지 정리한다.

## 현재 문맥

- 현재 로드맵 기준 완료 범위는 Sprint 05까지다
- 다음 집중 항목은 Sprint 06 `Product Reframing`이다
- 즉 구현은 아직 통합 워크스테이션의 최종 형태가 아니라, 그 방향으로 확장 가능한 셸 기반을 만드는 단계다

현재 앱은 다음 상태를 제공한다.

- Avalonia 기반 데스크톱 셸
- 좌측 워크스페이스, 중앙 문서 호스트, 우측 속성, 하단 로그/상태 영역
- `DagEdit`를 중앙 문서 영역에 임베드한 샘플 경로
- 임베드된 캔버스의 뷰포트/선택 상태를 셸 패널에 반영하는 동기화

## 솔루션 구조

저장소는 의도적으로 네 층으로 나뉜다.

### `src/CStudio.App`

앱 진입점과 Avalonia UI를 가진다.

- `Program.cs`: Avalonia 부트스트랩
- `App.axaml.cs`: 실제 조합 루트
- `Views/MainWindow.axaml`: Rider 스타일 셸 레이아웃
- `ViewModels/MainWindowViewModel.cs`: 셸 계약을 소비하는 단일 메인 뷰모델

중요한 점은 `App`이 직접 복잡한 로직을 갖지 않고, 서비스 조합 결과를 `MainWindowViewModel`에 주입한다는 것이다.

### `src/CStudio.Core`

제품 중립적인 셸 계약과 모델만 가진다.

- 모델: `DocumentTab`, `WorkspaceNode`, `PropertyEntry`, `LogEntry`, `ShellMenuItem`, `ShellBadge`
- 서비스 계약: `IWorkspaceService`, `IDocumentService`, `ISelectionService`, `IShellStateService`, `IPropertyPanelService`, `ILogService`, `IShellChromeService`
- 조합 레코드: `ShellServiceComposition`

이 프로젝트는 셸이 어떤 데이터를 소비하는지만 정의하고, 데이터가 어디서 오는지는 모른다.

### `src/CStudio.Mock`

목 기반 기본 구현을 제공한다.

- 샘플 워크스페이스 트리
- 샘플 문서
- 샘플 속성/로그/상태

초기 셸 개발을 실제 백엔드와 분리해서 진행하기 위한 계층이다.

### `src/CStudio.DagEditAdapter`

현재 유일한 실제 어댑터 경로다.

- `DagEditShellFactory`: 셸 조합 생성
- `DagEditShellContext`: `DagEditorViewModel` 중심의 어댑터 컨텍스트
- `DagEditDocumentView`: 실제 `DagEdit` 편집기 임베드
- `DagEditShellStateService`: 뷰포트/선택 상태를 셸 이벤트로 변환
- 나머지 서비스들: 셸 계약을 `DagEdit` 상태로 번역

핵심은 `DagEdit` 타입을 앱 UI 전체로 퍼뜨리지 않고, 어댑터 내부에서만 다루려는 방향이다.

## 실행 시 조합 흐름

현재 실행 흐름은 단순하다.

1. `Program`이 Avalonia 앱을 시작한다
2. `App.OnFrameworkInitializationCompleted()`가 `DagEditShellFactory.CreateSample()`을 호출한다
3. 팩토리가 `DagEditShellContext`와 각 서비스 구현을 묶어 `ShellServiceComposition`을 만든다
4. `MainWindowViewModel`이 이 서비스를 받아 UI 컬렉션과 상태를 초기화한다
5. 문서 선택 또는 셸 상태 변화가 발생하면 속성/로그/상태바/워크스페이스 라벨을 다시 채운다

즉 현재 `cstudio`는 DI 컨테이너보다 명시적 조합 루트에 가까운 구조다.

## UI 동작 방식

`MainWindowViewModel`은 셸 화면을 서비스 집합으로 렌더링한다.

- `WorkspaceService`: 좌측 탐색 영역 데이터
- `DocumentService`: 상단 탭과 중앙 문서 데이터
- `SelectionService`: 현재 선택된 문서 전환
- `PropertyPanelService`: 우측 속성 패널 데이터
- `LogService`: 하단 로그 데이터
- `ShellChromeService`: 메뉴, 배지, 상태바, 제목
- `ShellStateService`: 라이브 변경 이벤트 발생원

문서가 텍스트 기반이면 중앙에서 문자열을 보여주고, `ContentView`가 있으면 실제 Avalonia 뷰를 호스팅한다.

이 구조 덕분에 문서 호스트는 요약 문서와 실제 편집 표면을 같은 셸 안에서 다룰 수 있다.

## DagEdit 어댑터의 실제 역할

현재 앱의 데모 가치는 `DagEditAdapter`에 집중돼 있다.

### 샘플 그래프 구성

`DagEditShellContext.CreateSample()`은 샘플 노드와 연결을 만든 `DagEditorViewModel`을 준비한다.

즉 앱은 완전한 목 화면이 아니라, 실제 `DagEdit` 뷰모델을 바탕으로 셸을 구동한다.

### 문서 구성

`DagEditDocumentService`는 네 개 문서를 제공한다.

- `Dag Canvas`: 실제 임베드된 편집기 뷰
- `Dag Graph Overview`: 그래프 요약 텍스트
- `Viewport State`: 뷰포트 상태 요약
- `Connection Snapshot`: 연결 요약

즉 셸은 실제 편집 표면과 읽기 전용 진단 문서를 동시에 제공한다.

### 라이브 상태 동기화

`DagEditShellStateService`는 임베드된 `DagEditor`의 상태를 구독한다.

- 뷰포트 위치 변경
- 뷰포트 스케일 변경
- 선택 항목 변경

이 이벤트는 다시 속성 패널, 로그, 상태바, 상단 워크스페이스 라벨을 갱신하는 트리거가 된다.

Sprint 05의 구현 핵심은 바로 이 “임베드된 편집기의 라이브 상태를 셸 크롬으로 번역”하는 부분이다.

## 현재 아키텍처 특성

좋은 점은 명확하다.

- 셸 계약이 `Core`에 모여 있어 교체 가능한 구조다
- `Mock`과 `DagEditAdapter`가 같은 계약을 구현하므로 목 우선 개발 원칙을 유지한다
- UI는 서비스 소비자 역할에 집중하고, 백엔드 의미를 직접 알지 않는다
- `DagEdit` 의존은 어댑터 프로젝트 안에 가둬 두려는 방향이 보인다

아직 진행 중인 부분도 분명하다.

- 역할 기반 워크스페이스 분화는 아직 문서 단계이고 코드 구조는 단일 워크스페이스 셸에 가깝다
- 서비스 생명주기와 조합 방식은 아직 단순 수동 구성이다
- 문서/도구/패널 확장을 위한 플러그인성은 아직 본격화되지 않았다
- `DagEditDocumentView`는 샘플 뷰모델을 복제해서 임베드하므로, 장기적으로는 더 명확한 동기화 정책이 필요할 수 있다

## 품질 및 제약

저장소 전반에는 다음 운영 의도가 보인다.

- `Directory.Build.props`에서 코드 스타일 빌드 검사와 최신 분석기 레벨을 유지
- `StyleCop.Analyzers` 적용
- `TreatWarningsAsErrors=false`이지만 경고 증가 금지 정책 유지

의존성 측면에서는 주의점이 있다.

- `CStudio.DagEditAdapter`는 로컬 경로의 `DagEdit.csproj`를 직접 참조한다
- 따라서 이 저장소 단독으로 완결된 빌드보다, 주변 체크아웃을 전제로 한 개발 환경에 가깝다

## 현재 이해 요약

현재 `cstudio`는 “확장 가능한 Rider 스타일 셸”을 먼저 만들고, 그 셸에 `DagEdit`를 첫 실제 어댑터로 연결한 상태다.

핵심 설계 포인트는 다음 두 가지다.

- 셸 계약은 제품 중립적으로 유지한다
- 실제 도메인 편집기는 어댑터를 통해 셸에 연결한다

즉 이 프로젝트는 아직 완성된 통합 워크스테이션이라기보다, 그 방향을 검증하는 셸 플랫폼의 초기 구현으로 이해하는 것이 맞다.
