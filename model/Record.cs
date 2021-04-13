namespace ValleTemperatures.model
{
    class Record
    {
        public Record(string cod, string sensor, string fecha, double temperatura, string estacion, string dep, string mun, string zona, double lat, double lon, string descrip, string centi)
        {
            Cod = cod;
            Sensor = sensor;
            Fecha = fecha;
            Temperatura = temperatura;
            Estacion = estacion;
            Dep = dep;
            Mun = mun;
            Zona = zona;
            Lat = lat;
            Lon = lon;
            Descrip = descrip;
            Centi = centi;
        }

        public string Cod { get; set; }
        public string Sensor { get; set; }
        public string Fecha { get; set; }
        public double Temperatura { get; set; }
        public string Estacion { get; set; }
        public string Dep { get; set; }
        public string Mun { get; set; }
        public string Zona { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Descrip { get; set; }
        public string Centi { get; set; }


        public string[] TransformRecord2String()
        {
            string[] arrayRec = { Cod, Sensor, Fecha, Temperatura.ToString(), Estacion, Dep, Mun, Zona, Lat.ToString(), Lon.ToString(), Descrip, Centi };
            return arrayRec;
        }


    }
}
