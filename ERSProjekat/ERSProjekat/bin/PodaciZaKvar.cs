using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ERSProjekat
{
    public class PodaciZaKvar : IPodaciZaKvar
    {
        public string idKvara;
        public string nazivElementa;
        public string naponskiNivo;
        public List<Akcija> spisakAkcija;

        public PodaciZaKvar(string id,string naziv,string napon,List<Akcija> spisak)
        {
            idKvara = id;
            nazivElementa = naziv;
            naponskiNivo = napon;
            spisakAkcija = spisak;
        }


        public void sacuvajUExcelKvar(PodaciZaKvar KvarZaExcel)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                string Vreme = DateTime.Now.ToString("yyyyMMddHHmmss");
                string excelIme = $"Kvar_U_{Vreme}.xlsx";
                string excelPutanja = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, excelIme);

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    worksheet.Cells[1, 1].Value = "ID Kvara";
                    worksheet.Cells[1, 2].Value = "Naziv Elektricnog Elementa";
                    worksheet.Cells[1, 3].Value = "Napon";
                    worksheet.Cells[1, 4].Value = "Akcije";

                        worksheet.Cells[2, 1].Value = KvarZaExcel.idKvara;
                        worksheet.Cells[2, 2].Value = KvarZaExcel.nazivElementa;
                        worksheet.Cells[2, 3].Value = KvarZaExcel.naponskiNivo;

                        string listaAkcija = string.Join(Environment.NewLine, KvarZaExcel.spisakAkcija);
                        worksheet.Cells[2, 4].Value = listaAkcija;

                    package.SaveAs(new FileInfo(excelPutanja));
                    Console.WriteLine($"Uspjesno cuvanje u Excel fajl");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Greska: {e.Message}");
            }
        }

        //Podatke mozemo cuvati i u druge formate
    }
}
