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
        private List<PointLatLng> calculatedWPs;

        public RoadMode()
        {

        }

        public void getWPs()
        {

        }

        public void setWPs()
        {

        }

        private PointLatLng[] calculateWP(PointLatLng first, PointLatLng second, PointLatLng center, double distance)
        {
            double A;
            double B;
            double C;
            double c;
            double x0;
            double y0;
            double x1;
            double y1;

            double diff = Math.Abs(calculateDistanceBetweenPoints(first, second) - calculateDistanceBetweenPoints(first, new PointLatLng(second.Lat, second.Lng + 1.0))); //1 degree distance

            double radius = distance / diff;



            A = (first.Lat - second.Lat) / (first.Lng - second.Lng);
            B = -1;
            C = center.Lat - A * center.Lng;

            c = center.Lat + center.Lng / A;

            x0 = (radius * Math.Sqrt(Math.Pow(A, 2.0) + Math.Pow(B, 2.0)) - B * c - C) / (A - B / A);
            x1 = (radius * Math.Sqrt(Math.Pow(A, 2.0) + Math.Pow(B, 2.0)) + B * c + C) / (-A + B / A);
            y0 = -x0 / A + c;
            y1 = -x1 / A + c;

            PointLatLng[] result = new PointLatLng[2];
            result[0].Lat = y0;
            result[0].Lng = x0;
            result[1].Lat = y1;
            result[1].Lng = x1;

            return result;
        }

        private double calculateDistanceBetweenPoints(PointLatLng first,PointLatLng second) //calculates distance in metres
        {
            double R = 6371000;
            double fi1 = first.Lat*(Math.PI/180);
            double fi2 = second.Lat * (Math.PI / 180);
            double deltaFi = (second.Lat - first.Lat) * (Math.PI / 180);
            double deltaLambda = (second.Lng - first.Lng) * (Math.PI / 180);

            double a = Math.Sin(deltaFi / 2) * Math.Sin(deltaFi / 2) + Math.Cos(fi1) * Math.Cos(fi2) * Math.Sin(deltaLambda / 2) * Math.Sin(deltaLambda / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }
    }
}
