# CStudio Static Analysis Guardrails

## Purpose

This document defines the first commercial-grade code quality guardrails for `cstudio`.

The operating model follows the same direction already used in `DagEdit`:

- do not allow warning growth
- reduce existing warning debt gradually
- keep analyzer settings visible and honest

## Initial Policy

- `EnforceCodeStyleInBuild` stays enabled
- `Nullable` stays enabled
- `AnalysisLevel=latest` is enabled
- `AnalysisMode=All` is enabled
- `StyleCop.Analyzers` is enabled across the repository
- `TreatWarningsAsErrors` remains `false` for now
- GitHub Actions verifies build output and blocks warning regressions

This means the repository is not yet in full warning-as-error mode, but it is expected to trend toward lower warning counts without relaxing standards.

## Operating Rules

- New build warnings must not increase
- Static-analysis reduction work should be reported explicitly
- Feature work should not hide or defer newly introduced warnings
- Analyzer configuration must not be weakened just to silence findings
- Rider-visible warnings are treated as part of normal engineering quality, not optional cleanup
- GitHub Actions is allowed to start in bootstrap mode until a committed warning baseline is established

## Near-Term Goal

The immediate goal is to keep `cstudio` at zero build warnings while the shell is still young.

If a later batch introduces warnings due to expanded analyzers or new modules, the baseline should be recorded and then reduced intentionally rather than ignored.

## Follow-Up

`warning-baseline.json` is now committed from the first confirmed CI run.

From this point onward, the expected rule is simple: the warning count may go down or stay flat, but it must not go up.
