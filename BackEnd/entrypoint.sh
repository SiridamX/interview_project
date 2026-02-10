#!/bin/bash
set -e

PORT=${PORT:-5000}
export ASPNETCORE_URLS="http://*:${PORT}"

# 🔴 ระบุชื่อ App DLL ให้ชัด
APP_DLL="BackEnd.Api.dll"

if [ ! -f "$APP_DLL" ]; then
    echo "❌ Error: $APP_DLL not found in /app"
    echo "📂 Files in /app:"
    ls -la
    exit 1
fi

echo "🚀 Starting $APP_DLL on port ${PORT}..."
exec dotnet "$APP_DLL"

