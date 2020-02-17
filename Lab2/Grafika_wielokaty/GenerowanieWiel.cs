﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_wielokaty
{

    // ZRODLO - https://www.geeksforgeeks.org/convex-hull-set-1-jarviss-algorithm-or-wrapping/
    public class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class GenerowanieWiel
    {
        public static Wielokant generujWypukly(int n, int minx, int miny, int maxx, int maxy)
        {
            Random r = new Random();
            Point[] punkty = new Point[n];
            for (int i = 0;i<n;i++)
            {
                int x = r.Next(minx, maxx);
                int y = r.Next(miny, maxy);
                punkty[i] = new Point(x, y);

            }
            List<Point> listaPunktow = convexHull(punkty, n);
            if (listaPunktow == null) return null;
            Wielokant w = new Wielokant();
            w.kolor = Color.Black;
           
            foreach (var el in listaPunktow)
            {
                w.wierzcholki.Add(new Wierzcholek(el.x, el.y, w, Color.FromArgb(r.Next(20, 235), r.Next(20, 235), r.Next(20, 235))));
            }
            return w;
        }
        public static int orientation(Point p, Point q, Point r)
        {
            int val = (q.y - p.y) * (r.x - q.x) -
                    (q.x - p.x) * (r.y - q.y);

            if (val == 0) return 0; // collinear 
            return (val > 0) ? 1 : 2; // clock or counterclock wise 
        }

        // Prints convex hull of a set of n points. 
        public static List<Point> convexHull(Point[] points, int n)
        {
            // There must be at least 3 points 
            if (n < 3) return null;

            // Initialize Result 
            List<Point> hull = new List<Point>();

            // Find the leftmost point 
            int l = 0;
            for (int i = 1; i < n; i++)
                if (points[i].x < points[l].x)
                    l = i;

            // Start from leftmost point, keep moving  
            // counterclockwise until reach the start point 
            // again. This loop runs O(h) times where h is 
            // number of points in result or output. 
            int p = l, q;
            do
            {
                // Add current point to result 
                hull.Add(points[p]);

                // Search for a point 'q' such that  
                // orientation(p, x, q) is counterclockwise  
                // for all points 'x'. The idea is to keep  
                // track of last visited most counterclock- 
                // wise point in q. If any point 'i' is more  
                // counterclock-wise than q, then update q. 
                q = (p + 1) % n;

                for (int i = 0; i < n; i++)
                {
                    // If i is more counterclockwise than  
                    // current q, then update q 
                    if (orientation(points[p], points[i], points[q])
                                                        == 2)
                        q = i;
                }

                // Now q is the most counterclockwise with 
                // respect to p. Set p as q for next iteration,  
                // so that q is added to result 'hull' 
                p = q;

            } while (p != l); // While we don't come to first  
                              // point 

            // Print Result 
            return hull;
        }

    }
}