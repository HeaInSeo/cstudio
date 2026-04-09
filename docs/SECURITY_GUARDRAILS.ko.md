# CStudio 보안 가드레일

## 목적

이 문서는 `cstudio`의 첫 보안 중심 가드레일을 정의한다.

즉시 목표는 코드 품질 검증과 의존성 위험 검증을 분리해서, 각각의 신호가 섞이지 않고 바로 해석되게 만드는 것이다.

## 워크플로 분리

- `Verify`는 `cstudio` 코드 품질 가드레일용이다
- `Dependency Audit`는 `NuGet` 취약점 탐지용이다
- `DagEdit` 같은 체크아웃 참조의 누적 경고는 `cstudio` 정책 판단을 흐리게 하면 안 된다

## 현재 정책

- `Verify`는 `cstudio` 소유 코드 경고와 빌드 오류에만 집중해야 한다
- `Dependency Audit`는 `NuGetAudit=true`로 `dotnet restore`를 수행한다
- `Dependency Audit`는 `cstudio` 소유 restore 경로 기준으로만 취약점을 집계한다
- High, Critical 패키지 취약점은 `Dependency Audit`를 실패시킨다
- 감사 로그와 필터링된 취약점 보고서는 GitHub Actions artifact로 업로드한다

## 운영 의미

- `Verify` 실패는 셸 코드 품질 회귀를 의미한다
- `Dependency Audit` 실패는 의존성 위험에 대한 조치나 정책 판단이 필요하다는 뜻이다
- 이 둘은 성격이 다르므로 보고 체계도 분리돼야 한다

## 다음 단계

- 현재 보고되는 패키지 advisory를 추적한다
- 각 항목을 직접 패키지 업데이트, 프레임워크 업데이트, 임시 위험 수용 중 무엇으로 처리할지 결정한다
- 상용 릴리스 단계에서 필요할 때만 예외 프로세스를 두고, 그 경우에도 담당자와 만료 시점을 문서화한다
