# CStudio Security Guardrails

## Purpose

This document defines the first security-oriented guardrails for `cstudio`.

The immediate goal is to keep code-quality verification and dependency-risk verification separate, so each signal stays actionable.

## Workflow Split

- `Verify` is for `cstudio` code-quality guardrails
- `Dependency Audit` is for `NuGet` vulnerability detection
- External warning debt from checked-out references such as `DagEdit` must not weaken `cstudio` policy decisions

## Current Policy

- `Verify` must stay focused on `cstudio`-owned code warnings and build errors
- `Dependency Audit` runs `dotnet restore` with `NuGetAudit=true`
- `Dependency Audit` scopes findings to `cstudio`-owned restore paths
- High and critical package vulnerabilities fail `Dependency Audit`
- Audit logs and filtered vulnerability reports are uploaded as GitHub Actions artifacts

## Operational Meaning

- A failing `Verify` run means the shell code regressed
- A failing `Dependency Audit` run means dependency risk needs remediation or an explicit policy decision
- These are different classes of problems and should stay separated in reporting

## Next Step

- Track the currently reported package advisories
- Decide whether each finding should be resolved by direct package update, framework update, or accepted temporary risk
- Add an exception process only if commercial release needs it and the exception is documented with an owner and expiry
