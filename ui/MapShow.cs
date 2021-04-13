using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ValleTemperatures
{
    public partial class MapShow : Form
    {

        private List<PointLatLng> Markers;

        private GMapOverlay MarkersOverlay = new GMapOverlay("markers");

        public MapShow(List<double[]> marks)
        {
            InitializeComponent();
            Markers = new List<PointLatLng>();
            
            addMarkersToList(marks);
        }

        private void GMap_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            gmap.Position = new PointLatLng(3.416667, -76.516667);

            gmap.Overlays.Add(MarkersOverlay);
        }

        private void SetMarkers()
        {
            foreach (PointLatLng m in Markers)
            {
                GMarkerGoogle gMarkerGoogle = new GMarkerGoogle(m, GMarkerGoogleType.red_dot);
                GMapMarker marker = gMarkerGoogle;
                MarkersOverlay.Markers.Add(marker);
            }
        }

        private void addMarkersToList(List<double[]> marks)
        {
            foreach (double[] i in marks)
            {
                Markers.Add(new PointLatLng(i[0], i[1]));
            }
            SetMarkers();
        }

        

        private void Cerrar(object sender, EventArgs e)
        {
            this.Hide();
            Markers.Clear();
        }

        

        private void ocultar(object sender, EventArgs e)
        {
            if (MarkersOverlay.IsVisibile == false)
            {
                MessageBox.Show("Ya has ocultado los puntos!");
            }
            else
            {
                MessageBox.Show("Has ocultado los puntos.");
                MarkersOverlay.IsVisibile = false;
            }
        }

        private void mostrar(object sender, EventArgs e)
        {
            if (MarkersOverlay.IsVisibile == true)
            {
                MessageBox.Show("Los puntos ya estan en pantalla!");
            }
            else
            {
                MessageBox.Show("Has mostrado los puntos.");
                MarkersOverlay.IsVisibile = true;
            }
        }
    }
}
