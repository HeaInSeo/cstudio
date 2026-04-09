# CStudio 정적 분석 가드레일

## 목적

이 문서는 `cstudio`의 첫 상용 수준 코드 품질 가드레일을 정의한다.

운영 방식은 이미 `DagEdit`에서 사용 중인 방향을 따른다.

- 경고 증가 금지
- 기존 경고는 점진적으로 감축
- 분석기 설정은 숨기지 않고 정직하게 유지
- 신호 품질이 높아지는 예외 규칙은 `DagEdit` 기준과 맞춘다

## 초기 정책

- `EnforceCodeStyleInBuild` 유지
- `Nullable` 유지
- `AnalysisLevel=latest` 활성화
- `AnalysisMode=All` 활성화
- 저장소 전체에 `StyleCop.Analyzers` 적용
- 현재 단계에서는 `TreatWarningsAsErrors=false` 유지
- GitHub Actions에서 `cstudio` 소유 소스 기준의 경고 상태를 확인하고 회귀를 차단

즉 아직 모든 경고를 에러로 승격하지는 않지만, 기준을 느슨하게 하지 않은 채 경고 수를 낮추는 방향으로 운영한다.

## 운영 규칙

- 새 빌드 경고는 증가하면 안 된다
- 정적 분석 감축 작업은 별도로 명시해 보고한다
- 기능 작업 중 새로 생긴 경고를 숨기거나 다음으로 미루지 않는다
- 분석기 설정을 약화해서 경고를 없애는 방식은 금지한다
- Rider에서 보이는 경고도 선택적 정리가 아니라 기본 품질 항목으로 본다
- GitHub Actions는 초기 기준선이 확정되기 전까지 bootstrap 모드로 시작할 수 있다
- `DagEdit` 같은 체크아웃 의존성의 누적 경고는 `cstudio` 게이트 집계에 섞지 않는다

## 단기 목표

당장의 목표는 셸이 아직 작은 지금 단계에서 `cstudio`의 빌드 경고 0건을 유지하는 것이다.

이후 분석기 확대나 모듈 증가로 경고가 생기면, 그 시점의 기준선을 기록하고 의도적으로 줄여나가야 하며 방치하면 안 된다.

## 후속 단계

`warning-baseline.json`은 이제 GitHub Actions가 쓰는 더 좁은 `cstudio` 소유 경고 범위로 다시 고정됐다.

이제부터의 규칙은 단순하다. `cstudio` 경고 수는 줄거나 유지될 수는 있지만, 증가하면 안 된다.

## 관련 가드레일

의존성 취약점 점검은 이제 `Dependency Audit`로 분리해 다룬다.

[SECURITY_GUARDRAILS.ko.md](./SECURITY_GUARDRAILS.ko.md)를 참고한다.
