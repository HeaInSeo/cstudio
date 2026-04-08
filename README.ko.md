# cstudio

`cstudio`는 `GPU-Reshape` Studio UI를 참고해 만드는 제품 중립 Avalonia 데스크톱 셸이며, 향후 `DagEdit`에 UI를 더 쉽게 이식하기 위한 전단계 프로젝트다.

영문 버전:

- [README.md](README.md)

## 현재 범위

현재는 Sprint 3 완료 상태이며, 지금까지 확보된 기본 셸은 다음을 포함한다.

- 메인 윈도우
- 워크스페이스/탐색 셸
- 중앙 문서 호스트
- 속성 패널
- 로그 및 상태 영역
- 목 구현 위의 어댑터 준비형 셸 계약 구조
- 첫 DagEdit 연동 어댑터 경로

## 참고 기준

주 UI 참고 원본:

- `GPU-Reshape/Source/UIX/Studio`

비 UI 설정 참고:

- `DagEdit`
- `NodeKit`
- `virtualcanvas-avalonia`

## 계획 문서

- [Roadmap (EN)](docs/ROADMAP.en.md)
- [로드맵 (KO)](docs/ROADMAP.ko.md)
