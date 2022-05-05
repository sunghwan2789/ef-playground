#!/usr/bin/env sh

command=$1
arg=$2

for dataProvider in src/Infrastructure.*
do
    echo Visiting $dataProvider...
    dotnet ef migrations $command $arg --project $dataProvider
done
