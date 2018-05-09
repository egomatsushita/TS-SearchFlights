## TS - Search Flights

TS_SearchFlights is a console application that takes data from three separate provider text files with the following command line "$searchFlights -o {Origin} -d {Destination}". It uses C# with 4.6.1 .NET Framework.

## Main Features

- Users can search for flights giving origin and destination.
- Users can search for flights many times in one session.
- Users can follow the instructions panel.
- Display one flight per line.
- Remove duplicate rows.
- Order by "Price" first in ascending order, then by "Departure Time" in ascending order.
- Display "No Flights Found for {Origin} --> {Destination}" when flights aren't found. 
- Unit test

## Screenshots

### One Search
![One_Search](*)

### Two Searches
![Two_Searches](*)

### Error
![Error](*)

## Install

1. Clone the repo: `https://github.com/egomatsushita/TS-SearchFlights`
2. Open Visual Studio
3. In the Visual Studio, File > Open > Project/Solution > TS_Search_Flights.sln
4. To run: click on "Start" or "Ctrl + F5" or "Debug > Start Without Debuggin"