# Sprint 03 - DagEdit Adapter Pass

영문 버전:

- [sprint-03-dagedit-adapter.md](sprint-03-dagedit-adapter.md)

## 목표

`cstudio` 셸에 첫 실제 DagEdit 기반 어댑터 경로를 도입한다.

## 범위

- 전용 `CStudio.DagEditAdapter` 프로젝트 추가
- 실제 `DagEdit` 타입 참조
- 샘플 `DagEditorViewModel` 구성
- DagEdit의 그래프, 뷰포트, 카운트 상태를 cstudio 셸 계약으로 매핑
- 앱 조합을 순수 Mock 경로에서 DagEdit 어댑터 경로로 전환

## 완료 기준

- 솔루션이 성공적으로 빌드된다
- cstudio가 DagEdit 어댑터 경로를 통해 셸 서비스를 조합한다
- 셸 문서와 상태 영역이 DagEdit 유래 상태를 반영한다
- GitHub에서 볼 수 있는 스크린샷 문서가 갱신된다

## 상태

완료.
