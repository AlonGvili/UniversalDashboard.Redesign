FROM gitpod/workspace-full-vnc:latest

USER root

RUN apt-get update \
    && apt-get install -y /tmp/powershell.deb \
    && apt-get dist-upgrade -y \
    && apt-get clean \
    && pwsh -NoLogo -NoProfile -c "install-module -Name Pester -Scope CurrentUser -force" \
    && cd .\src \
    && pwsh -NoLogo -NoProfile -c "build.ps1" \