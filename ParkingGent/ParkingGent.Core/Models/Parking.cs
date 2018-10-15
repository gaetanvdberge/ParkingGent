using System;
using System.Collections.Generic;
using CoreLocation;
using MapKit;

namespace ParkingGent.Core.Models
{
    public class Parking
    {
        public int id { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string address { get; set; }
        public string contactInfo { get; set; }
        public City city { get; set; }
        public ParkingServer parkingServer { get; set; }
        public int suggestedFreeThreshold { get; set; }
        public int suggestedFullThreshold { get; set; }
        public int capacityRounding { get; set; }
        public int totalCapacity { get; set; }
        public IList<OpeningTime> openingTimes { get; set; }
        public ParkingStatus parkingStatus { get; set; }
        public bool? blurAvailability { get; set; }


        public class City
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class ParkingServer
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class OpeningTime
        {
            public IList<string> days { get; set; }
            public string from { get; set; }
            public string to { get; set; }
        }

        public class ParkingStatus
        {
            public int availableCapacity { get; set; }
            public int totalCapacity { get; set; }
            public bool open { get; set; }
            public string suggestedCapacity { get; set; }
            public string activeRoute { get; set; }
            public string lastModifiedDate { get; set; }
        }

        public string AvailablePlacesString
        {
            get { return parkingStatus.availableCapacity.ToString() + "/" + parkingStatus.totalCapacity.ToString(); }
        }

        public string NavigateLinkAppleMaps
        {
            get { return "http://maps.apple.com/?daddr=Parking+" + description.Replace(" ", "+") + "+Gent&dirflg=d&t=h"; }
        }

        public string NavigateLinkGoogleMaps
        {
            get { return "https://www.google.com/maps/dir/?api=1&destination=Parking+" + description.Replace(" ", "+") + "+Gent"; }
        }

        public string NavigateLinkWaze
        {
            get { return "https://waze.com/ul?ll=" + latitude + "," + longitude + "&navigate=yes";
 }
        }

        public MapKit.IMKAnnotation MapAnnotation
        {
            get { return new MapKit.MKPointAnnotation() { Title = description, Subtitle = address, Coordinate = new CLLocationCoordinate2D(latitude, longitude) }; }
        }

        public float Progress
        {
            get { return 1 - Convert.ToSingle((float)parkingStatus.availableCapacity / parkingStatus.totalCapacity); }
        }

        public int PlacesTaken
        {
            get { return parkingStatus.totalCapacity - parkingStatus.availableCapacity; }
        }

    }
}

