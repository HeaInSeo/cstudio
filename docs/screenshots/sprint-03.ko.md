# Sprint 03 스크린샷 노트

영문 버전:

- [sprint-03.md](sprint-03.md)

## 개요

Sprint 03에서는 첫 DagEdit 기반 어댑터 패스를 도입했다.

셸의 외형은 여전히 GPU-Reshape 참고 구조를 유지하지만, 화면에 보이는 내용은 이제 cstudio 셸 계약을 통해 라우팅된 DagEdit 샘플 상태를 반영한다.

## 미리보기

![Sprint 03 shell preview](assets/sprint-03-shell-preview.svg)

## 이번 스프린트의 시각적 신호

- `DagEdit Adapter` 액션 배지
- DagEdit 기반 워크스페이스 라벨
- 상태바와 워크스페이스 섹션의 DagEdit 노드/커넥션 메트릭
- DagEdit 중심 문서 제목 및 속성 값

## 메모

- 이것은 첫 어댑터 패스이며, 전체 앱 임베딩은 아니다.
- 셸 재사용성은 유지되고, DagEdit는 계약 계층을 통해 매핑된다.

## 상태

완료 및 GitHub 반영 완료.
