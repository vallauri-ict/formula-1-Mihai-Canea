```
    ███████╗ ██████╗ ██╗          ██████╗██████╗ ███████╗ █████╗ ████████╗ ██████╗ ██████╗ 
    ██╔════╝██╔═══██╗██║         ██╔════╝██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗
    ███████╗██║   ██║██║         ██║     ██████╔╝█████╗  ███████║   ██║   ██║   ██║██████╔╝
    ╚════██║██║▄▄ ██║██║         ██║     ██╔══██╗██╔══╝  ██╔══██║   ██║   ██║   ██║██╔══██╗
    ███████║╚██████╔╝███████╗    ╚██████╗██║  ██║███████╗██║  ██║   ██║   ╚██████╔╝██║  ██║
    ╚══════╝ ╚══▀▀═╝ ╚══════╝     ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝
```

### About
Simple tool for convert your **JSON** file into **MSSQL** table

**IMPORTANT**: in this project you can convert JSON file from [Scrapy](https://docs.scrapy.org/en/latest/) output

### Usage
```
[-t] [<DB table name>]: insert JSON file name from scrapy output
[-o] [Name output file]: Export data
```

## Example
From this:
```json
{
    "TeamName": "Ferrari",
    "FullTeamName": "Scuderia Ferrari Mission Winnow",
    "Base": "Maranello, Italy",
    "TeamChief": "Mattia Binotto",
    "TechnicalChief": "Simone Resta",
    "Chassis": "SF1000",
    "PowerUnit": "Ferrari",
    "FirstTeamEntry": "1950",
    "WorldChampionships": "16",
    "HighestRaceFinish": "1 (x239)",
    "PolePosition": "221",
    "FastestLaps": "253"
}
```
to this:
```sql
INSERT INTO [dbo].[Teams](
	TeamName,
	FullTeamName,
	Base,
	TeamChief,
	TechnicalChief,
	Chassis,
	PowerUnit,
	FirstTeamEntry,
	WorldChampionships,
	HighestRaceFinish,
	PolePosition,
	FastestLaps
)
VALUES(
  'Ferrari',
  'Scuderia Ferrari Mission Winnow',
  'Maranello, Italy',
  'Mattia Binotto',
  'Simone Resta',
  'SF1000',
  'Ferrari',
  '1950',
  '16',
  '1 (x239)',
  '221',
  '253'
);
```
