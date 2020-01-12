FROM powershell:latest

USER root

RUN apt-get update \
    && apt-get --yes install docker \
    && pwsh -NoLogo -NoProfile -c "install-module -Name Pester -Scope CurrentUser -force" \
    && cd .\src \
    && pwsh -NoLogo -NoProfile -c "build.ps1"