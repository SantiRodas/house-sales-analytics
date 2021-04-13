using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ValleTemperatures.model
{
    class Controller
    {


        public List<Record> Records { get; set; }
        public Hashtable promedioTemperaturaPorMunicipio { get; set; }
        public List<double[]> Coordenadas { get; set; }
        public Hashtable cantidadZonaHidrografica { get; set; }
        public Hashtable cantidadRegistrosPorMunicipio { get; set; }

       
        public Controller()
        {
            Records = new List<Record>();
            Coordenadas = new List<double[]>();
            promedioTemperaturaPorMunicipio = new Hashtable();
            cantidadZonaHidrografica = new Hashtable();
            cantidadRegistrosPorMunicipio = new Hashtable();
        }

        public List<double[]> GetCoordenadas() 
        {
            return Coordenadas;
        }



        public void AddRecord(Record rec)
        {
            Records.Add(rec);
            AddRecord2Hashtables(rec);
            AddRec2Coordenadas(rec);
        }

        public void AddRecord2Hashtables(Record rec)
        {
            

            int oneUnit = 1;
            double[] arrayForAverage = { 0, 0 };

            if (promedioTemperaturaPorMunicipio.ContainsKey(rec.Mun))
            {
                

                object objArray = promedioTemperaturaPorMunicipio[rec.Mun];

                if (objArray != null)
                {
                    arrayForAverage = (double[])objArray;

                    arrayForAverage[0] = arrayForAverage[0] + rec.Temperatura;
                    arrayForAverage[1] = arrayForAverage[1] + 1;

                    promedioTemperaturaPorMunicipio[rec.Mun] = arrayForAverage;
                }


            }
            else
            {
                arrayForAverage[0] = rec.Temperatura;
                arrayForAverage[1] = 1;
                promedioTemperaturaPorMunicipio.Add(rec.Mun, arrayForAverage);
            }


            if (cantidadZonaHidrografica.ContainsKey(rec.Zona))
            {
                cantidadZonaHidrografica[rec.Zona] = ((int)cantidadZonaHidrografica[rec.Zona]) + 1;
            }
            else
            {

                cantidadZonaHidrografica.Add(rec.Zona, oneUnit);
            }


            if (cantidadRegistrosPorMunicipio.ContainsKey(rec.Mun))
            {
                cantidadRegistrosPorMunicipio[rec.Mun] = ((int)cantidadRegistrosPorMunicipio[rec.Mun]) + 1;
            }
            else
            {
                cantidadRegistrosPorMunicipio.Add(rec.Mun, oneUnit);
            }
        }

        public Hashtable ShowHashT()
        {
            return promedioTemperaturaPorMunicipio;
        }



        public List<string[]> GetOriginalRecords()
        {
            List<string[]> dataString = new List<string[]>();
            promedioTemperaturaPorMunicipio.Clear();
            cantidadZonaHidrografica.Clear();
            cantidadRegistrosPorMunicipio.Clear();
            Coordenadas.Clear();

            foreach (Record rec in Records)
            {
                string[] line = rec.TransformRecord2String();
                dataString.Add(line);
                AddRecord2Hashtables(rec);
                AddRec2Coordenadas(rec);
            }

            return dataString;
        }

        public List<string[]> FilterByMun(string comboBoxText)
        {
            List<string[]> rowsDvg = new List<string[]>();
            promedioTemperaturaPorMunicipio.Clear();
            cantidadZonaHidrografica.Clear();
            cantidadRegistrosPorMunicipio.Clear();
            Coordenadas.Clear();

            foreach (Record mun in Records)
            {
                string munName = mun.Mun;
                if (munName.Equals(comboBoxText, StringComparison.InvariantCultureIgnoreCase))
                {
                    string[] line = mun.TransformRecord2String();
                    rowsDvg.Add(line);
                    AddRecord2Hashtables(mun);
                    AddRec2Coordenadas(mun);
                }
            }



            return rowsDvg;
        }



        public List<string[]> FilterByZona(string textBoxText)
        {
            List<string[]> rowsDvg = new List<string[]>();
            promedioTemperaturaPorMunicipio.Clear();
            cantidadZonaHidrografica.Clear();
            cantidadRegistrosPorMunicipio.Clear();
            Coordenadas.Clear();

            foreach (Record mun in Records)
            {
                string munZona = mun.Zona;
                munZona = munZona.ToUpper();

                textBoxText = textBoxText.ToUpper();

                if (munZona.Contains(textBoxText))
                {
                    string[] line = mun.TransformRecord2String();
                    rowsDvg.Add(line);
                    AddRecord2Hashtables(mun);
                    AddRec2Coordenadas(mun);
                }
            }



            return rowsDvg;
        }



        public List<string[]> FilterByRange(double minValue, double maxValue)
        {
            List<string[]> rowsDvg = new List<string[]>();
            promedioTemperaturaPorMunicipio.Clear();
            cantidadZonaHidrografica.Clear();
            cantidadRegistrosPorMunicipio.Clear();
            Coordenadas.Clear();

            foreach (Record mun in Records)
            {

                if ((mun.Temperatura >= minValue) && (mun.Temperatura <= maxValue))
                {
                    string[] line = mun.TransformRecord2String();
                    rowsDvg.Add(line);
                    AddRecord2Hashtables(mun);
                    AddRec2Coordenadas(mun);
                }

               
            }



            return rowsDvg;
        }




        public void AddRec2Coordenadas(Record rec) 

        {
            double[] cor = new double[2];
            cor[0] = rec.Lat;
            cor[1] = rec.Lon;
            Coordenadas.Add(cor);
        }

           
    
        public List<string[]> CandidadMunicipio()
        {
            List<string[]> datos = new List<string[]>();
            foreach (DictionaryEntry i in cantidadRegistrosPorMunicipio)
            {
                string[] dato = new string[2];

                dato[0] = (string)i.Key;
                dato[1] = "" + i.Value;
                datos.Add(dato);
            }

            return datos;
        }

        public List<string[]> TemperaturaCiudad()
        {
            List<string[]> datos = new List<string[]>();
            foreach (DictionaryEntry i in promedioTemperaturaPorMunicipio)
            {
                string[] dato = new string[2];
                double[] temperaturas = (double[]) i.Value;
                double a = temperaturas[0];
                double b = temperaturas[1];
                double c = a / b;
                dato[0] = c.ToString();
                dato[1] = i.Key.ToString();
                Console.WriteLine(dato[1]);
                datos.Add(dato);
            }

            return datos;
        }

        public List<string[]> CantidadZona()
        {
            List<string[]> datos = new List<string[]>();
            foreach (DictionaryEntry i in cantidadZonaHidrografica)
            {
                string[] dato = new string[2];

                dato[0] = (string)i.Key;
                dato[1] = "" + i.Value;
                datos.Add(dato);
            }

            return datos;
        }


    }
}
