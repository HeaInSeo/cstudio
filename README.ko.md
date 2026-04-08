# cstudio

`cstudio`는 `GPU-Reshape` Studio UI를 참고해 만드는 Rider 스타일 Avalonia 데스크톱 워크스테이션 셸이다. 이제는 단순한 임시 프로토타입이 아니라, 향후 파이프라인 편집, 관리자 authoring, 운영 기능을 함께 담는 통합 호스트 후보로 보고 있다.

영문 버전:

- [README.md](README.md)

## 현재 범위

현재는 Sprint 5 완료 상태이며, 지금까지 확보된 기본 셸은 다음을 포함한다.

- 메인 윈도우
- 워크스페이스/탐색 셸
- 중앙 문서 호스트
- 속성 패널
- 로그 및 상태 영역
- 목 구현 위의 어댑터 준비형 셸 계약 구조
- 첫 DagEdit 연동 어댑터 경로
- 중앙 문서 호스트 안에 임베드된 실제 DagEdit 캔버스
- 라이브 뷰포트 및 선택 상태로 갱신되는 셸 패널

## 제품 방향

`cstudio`는 더 이상 `DagEdit`만을 위한 일회성 전단계 셸로 보지 않는다.

이제는 아래를 수용하는 통합 워크스테이션 후보로 정의한다.

- 파이프라인 작성 및 그래프 편집
- 관리자 전용 Tool authoring / validation 흐름
- 향후 Kubernetes 운영 및 런타임 관찰 화면

시각적 방향은 계속 `GPU-Reshape/Studio`에서 본 IDE형 셸 구조를 따른다. 참고 이유는 `GPU-Reshape` 자체 기능보다 Rider 계열 작업 방식에 가깝기 때문이다.

## 확장성

`cstudio`의 기능 범위는 앞으로 얼마든지 늘어날 수 있다.

따라서 이 프로젝트는 고정 범위 앱이 아니라, 새로운 워크스페이스와 패널, 권한별 도구를 계속 흡수할 수 있는 확장형 플랫폼 셸로 다뤄야 한다.

## 코드 품질 가드레일

`cstudio`는 `DagEdit`에서 운영 중인 정적 분석 방향을 같은 기준선으로 채택한다.

- 빌드 시 코드 스타일 강제는 계속 유지
- 새 경고는 증가하면 안 됨
- 경고 감축은 별도의 품질 트랙으로 운영
- Rider에서 보이는 경고는 시간이 갈수록 줄어드는 방향으로 관리

## 참고 기준

주 UI 참고 원본:

- `GPU-Reshape/Source/UIX/Studio`

기능/모듈 참고:

- `DagEdit`
- `NodeKit`
- `KubeUI`
- `virtualcanvas-avalonia`

## 계획 문서

- [Roadmap (EN)](docs/ROADMAP.en.md)
- [로드맵 (KO)](docs/ROADMAP.ko.md)
- [Architecture Direction (EN)](docs/ARCHITECTURE.en.md)
- [아키텍처 방향 (KO)](docs/ARCHITECTURE.ko.md)
- [Static Analysis Guardrails (EN)](docs/STATIC_ANALYSIS_GUARDRAILS.en.md)
- [정적 분석 가드레일 (KO)](docs/STATIC_ANALYSIS_GUARDRAILS.ko.md)
