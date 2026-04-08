# CStudio 아키텍처 방향

## 요약

`cstudio`는 Rider 스타일의 통합 워크스테이션 셸로 재정의되고 있다.

주 시각 참고 기준은 계속 `GPU-Reshape/Studio`다. 이유는 그 제품 도메인 때문이 아니라, IDE형 셸 구조가 `cstudio`가 지향하는 작업 방식과 맞기 때문이다.

## 셸의 의도

`cstudio`는 여러 역할 기반 워크스페이스를 담는 단일 데스크톱 호스트가 되어야 한다.

셸 자체는 안정적으로 유지하고, 그 안의 기능은 계속 확장될 수 있어야 한다.

## 역할 기반 워크스페이스

- `Pipeline Workspace`
  - 그래프 편집
  - 파이프라인 구성
  - 실행 중심의 문서/속성 화면
- `Admin Workspace`
  - Tool authoring
  - validation
  - 정책 및 build/register 흐름
- `Operations Workspace`
  - 향후 Kubernetes 운영/관찰 기능
  - 실행 진단
  - 환경 가시성

## 참고 대상 매핑

- `GPU-Reshape/Studio`
  - 셸 형태
  - 도킹 모델
  - 패널 계층
  - IDE형 작업 흐름
- `DagEdit`
  - 파이프라인 캔버스
  - 노드/엣지 편집 의미
- `NodeKit`
  - 관리자 authoring 개념
  - validation / registration 흐름
- `KubeUI`
  - 향후 Kubernetes 관리 기능 영역 참고
  - UI 템플릿이 아니라 운영 도메인 참고 대상으로 사용

## 제품 가정

`cstudio`는 고정 범위 앱으로 다루면 안 된다.

기능 세트는 시간이 지나며 크게 확장될 수 있으므로, 아키텍처와 네비게이션은 새로운 워크스페이스, 패널, 서비스가 추가돼도 셸 전체를 다시 짜지 않도록 설계해야 한다.

## 현재 아키텍처 원칙

셸은 통합하되, 기능 책임은 분리한다.

즉 하나의 워크스테이션 앱 안에 여러 도메인을 담더라도, 파이프라인 편집, 관리자 authoring, 향후 운영 로직은 명확한 계약 뒤에 모듈식으로 유지해야 한다.
