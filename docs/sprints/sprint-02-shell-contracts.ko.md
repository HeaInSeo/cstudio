# Sprint 02 - Shell Contracts

영문 버전:

- [sprint-02-shell-contracts.md](sprint-02-shell-contracts.md)

## 목표

직접적인 `Mock -> ViewModel` 연결을 제거하고, 어댑터 가능한 셸 서비스 계약 구조로 전환한다.

## 범위

- 셸 데이터 접근을 전용 Core 서비스 인터페이스로 분리
- Mock 구현을 `CStudio.Mock`로 이동
- `App`을 셸 서비스 조합 루트로 사용
- `MainWindowViewModel`이 구체 Mock 생성 대신 계약에 의존하도록 변경
- 선택 상태에 따른 속성 갱신을 계약 경계 안에서 유지

## 완료 기준

- 앱이 성공적으로 빌드된다
- `MainWindowViewModel`이 더 이상 Mock 서비스를 직접 생성하지 않는다
- 셸 상태가 `Core` 계약을 통해 조합된다
- GitHub에서 볼 수 있는 스크린샷 문서가 갱신된다

## 상태

완료.
