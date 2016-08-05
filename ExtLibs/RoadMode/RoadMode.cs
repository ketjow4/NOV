using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;

namespace MissionPlanner
{
    public class RoadMode
    {
        private List<PointLatLng> origWaypoints;
        private List<PointLatLng> calculatedWPs = new List<PointLatLng>();
        private double oneDegNSLength;
        private double oneDegWELength;


        public RoadMode(List<PointLatLng> list)
        {
            origWaypoints = list;
            oneDegNSLength = calculateDistanceBetweenPoints(new PointLatLng(0, 0), new PointLatLng(1, 0));

            if(origWaypoints.Count>0)
            oneDegWELength = calculateDistanceBetweenPoints(new PointLatLng(origWaypoints[0].Lat, 0), new PointLatLng(origWaypoints[0].Lat, 1));
        }

        public List<PointLatLng> getWPs()
        {
            return calculatedWPs;
        }

        public void setWPs()
        {
            //int Alt = 25;

            //foreach(PointLatLng p in calculatedWPs)
            //{
            //    plugin.Host.AddWPtoList(MAVLink.MAV_CMD.WAYPOINT, 0, 0, 0, 0, p.Lng, p.Lat, Alt * CurrentState.multiplierdist);
            //}
           
        }

        public void work(double distance)
        {
            List<PointLatLng> list1 = new List<PointLatLng>();
            List<PointLatLng> list2 = new List<PointLatLng>();
            PointLatLng[] res = new PointLatLng[2];

            res = calculateWP(origWaypoints[0], origWaypoints[1], origWaypoints[0], distance); //calculate waypoints in the beginning
            list1.Add(res[0]);
            list2.Add(res[1]);

            for(int i=0;i<origWaypoints.Count-1;i++)
            {
                PointLatLng center = new PointLatLng((origWaypoints[i].Lat + origWaypoints[i + 1].Lat) / 2, (origWaypoints[i].Lng + origWaypoints[i + 1].Lng) / 2);
                res = calculateWP(origWaypoints[i], origWaypoints[i+1], center, distance);
                list1.Add(res[0]);
                list2.Add(res[1]);
            }
            res = calculateWP(origWaypoints[origWaypoints.Count-2], origWaypoints[origWaypoints.Count - 1], origWaypoints[origWaypoints.Count - 1], distance); //calculate waypoints in the end
            list1.Add(res[0]);
            list2.Add(res[1]);

            list1.Reverse();

            for(int i = 0; i < list1.Count; i++)
            {
                calculatedWPs.Add(list1[i]);
            }

            for(int i =0;i<list2.Count;i++)
            {
                calculatedWPs.Add(list2[i]);
            }

        }

        private PointLatLng[] calculateWP(PointLatLng first, PointLatLng second, PointLatLng center, double distance)
        {
            //line between points parametres
            double A;
            double B;
            double C;

            //perpendicular line offset
            double c;

            //coordinates of result waypoints
            double x0;
            double y0;
            double x1;
            double y1;

            A = (first.Lat - second.Lat) / (first.Lng - second.Lng);

             double length = Math.Sqrt(1.0 + Math.Pow(A, 2.0));

            // double diff = calculateDistanceBetweenPoints(first, new PointLatLng(first.Lat+A, first.Lng + 1.0)); 

            double diff = Math.Sqrt(Math.Pow(1.0*oneDegWELength,2.0)+Math.Pow(A*oneDegNSLength,2.0));

            double radius = distance / (diff/length);


       
            B = -1;
            C = center.Lat - A * center.Lng;

            c = center.Lat + center.Lng / A;

            x1 = (radius * Math.Sqrt(Math.Pow(A, 2.0) + Math.Pow(B, 2.0)) - B * c - C) / (A - B / A);
            x0 = (radius * Math.Sqrt(Math.Pow(A, 2.0) + Math.Pow(B, 2.0)) + B * c + C) / (-A + B / A);
            y0 = -x0 / A + c;
            y1 = -x1 / A + c;

            PointLatLng[] result = new PointLatLng[2];
            result[0].Lat = y0;
            result[0].Lng = x0;
            result[1].Lat = y1;
            result[1].Lng = x1;

            return result;
        }

        private double calculateDistanceBetweenPoints(PointLatLng first,PointLatLng second) //calculates distance in metres http://www.movable-type.co.uk/scripts/latlong.html
        {
            double R = 6371000;
            double fi1 = first.Lat*(Math.PI/180.0);
            double fi2 = second.Lat * (Math.PI / 180.0);
            double deltaFi = (second.Lat - first.Lat) * (Math.PI / 180.0);
            double deltaLambda = (second.Lng - first.Lng) * (Math.PI / 180.0);

            double a = Math.Sin(deltaFi / 2.0) * Math.Sin(deltaFi / 2.0) + Math.Cos(fi1) * Math.Cos(fi2) * Math.Sin(deltaLambda / 2.0) * Math.Sin(deltaLambda / 2.0);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            return R * c;
        }
    }
}
