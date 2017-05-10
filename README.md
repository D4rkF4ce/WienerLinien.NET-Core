# WienerLinien.NET-Core
Port to .Net Core Framework (UWP) from https://github.com/KarimDarwish/WienerLinien.NET

# Using
            
            Debug.WriteLine("Start");
            var context = new WienerLinienContext("YOUR_KEY_HERE");
            var allStations = await Stations.GetAllStationsAsync();

            //initialize the RealtimeData object using the created context
            var rtd = new RealtimeData(context);

            var listRbls = new List<int>();

            var station = "Meidling";
            Debug.WriteLine("");

            // the desired station
            var SelectedStation = allStations.Find(x => station != null && x.Name.Contains(station));
            var plattform = "U6";

            var StationLines = SelectedStation.Platforms.FindAll(x => x.Name.Equals(plattform));
            foreach (var x in StationLines)
                listRbls.Add(x.RblNumber);

            //Create a Parameters object to include the Rbls  and get Realtime Data for them
            var parameters = new Parameters.MonitorParameters() { Rbls = listRbls };

            //Get the monitor informatino asynchronous, and save them as MonitorData class
            var monitorInfo = await rtd.GetMonitorDataAsync(parameters);

            foreach (var m in monitorInfo.Data.Monitors)
            {
                foreach (var lineIterate in m.Lines)
                    if (lineIterate.Name.Equals(plattform))
                    {
                        Debug.WriteLine("");
                        Debug.WriteLine(lineIterate.Name + " " + lineIterate.Towards);
                        lineIterate.Departures.Departure.ForEach(x => Debug.WriteLine(" " + x.DepartureTime.TimePlanned.Normalize().Substring(11, 5)));
                    }
            }
