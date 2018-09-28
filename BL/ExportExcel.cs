using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace BL
{
  public class ExportExcel
  {

      public void exportar_Excel(System.Data.DataTable _dataTable, String _empresa, String _sucursal, DateTime _dateinicio, DateTime _datefinal)
      {
          Application _excel = new Application();
          Workbook _excelBook = _excel.Workbooks.Add(XlSheetType.xlWorksheet);
          Worksheet _excelSheet = (Worksheet)_excel.ActiveSheet;

          _excelSheet.Visible = XlSheetVisibility.xlSheetVisible;
          _excelSheet.Name = "ReporteExcel";

          _excelSheet.Cells[1, 1] = "EMPRESA";
          _excelSheet.get_Range(_excelSheet.Cells[1, 2], _excelSheet.Cells[1, 3]).MergeCells = true;
          _excelSheet.Cells[1, 2] = _empresa;
          _excelSheet.Cells[1, 7] = "FECHA";
          _excelSheet.get_Range(_excelSheet.Cells[1, 8], _excelSheet.Cells[1, 9]).MergeCells = true;
          _excelSheet.Cells[1, 8] = DateTime.Now.ToShortDateString(); ;

          _excelSheet.Cells[2, 1] = "SUCURSAL";
          _excelSheet.get_Range(_excelSheet.Cells[2, 2], _excelSheet.Cells[2, 3]).MergeCells = true;
          _excelSheet.Cells[2, 2] = _sucursal;
          _excelSheet.Cells[2, 7] = "HORA";
          _excelSheet.get_Range(_excelSheet.Cells[2, 8], _excelSheet.Cells[2, 9]).MergeCells = true;
          _excelSheet.Cells[2, 8] = DateTime.Now.ToShortTimeString();

          _excelSheet.get_Range(_excelSheet.Cells[3, 4], _excelSheet.Cells[3, 5]).MergeCells = true;
          _excelSheet.get_Range(_excelSheet.Cells[3, 4], _excelSheet.Cells[3, 5]).Font.Bold = true;
          _excelSheet.get_Range(_excelSheet.Cells[3, 4], _excelSheet.Cells[3, 5]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
          _excelSheet.Cells[3, 4] = "ESTADOS DE CUENTA";

          _excelSheet.get_Range(_excelSheet.Cells[4, 4], _excelSheet.Cells[4, 5]).MergeCells = true;
          _excelSheet.get_Range(_excelSheet.Cells[4, 4], _excelSheet.Cells[4, 5]).Font.Bold = false;
          _excelSheet.get_Range(_excelSheet.Cells[4, 4], _excelSheet.Cells[4, 5]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
          _excelSheet.Cells[4, 4] = "(" + _dateinicio.ToString("yyyy/MM/dd") + " - " + _datefinal.ToString("yyyy/MM/dd") + ")";

          _excelSheet.get_Range(_excelSheet.Cells[5, 3], _excelSheet.Cells[5, 5]).MergeCells = true;
          _excelSheet.get_Range(_excelSheet.Cells[5, 3], _excelSheet.Cells[5, 5]).Borders.Color = 000;
          _excelSheet.get_Range(_excelSheet.Cells[5, 3], _excelSheet.Cells[5, 5]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
          _excelSheet.Cells[5, 3] = "SOLES";
          _excelSheet.get_Range(_excelSheet.Cells[5, 6], _excelSheet.Cells[5, 8]).MergeCells = true;
          _excelSheet.get_Range(_excelSheet.Cells[5, 6], _excelSheet.Cells[5, 8]).Borders.Color = 000;
          _excelSheet.get_Range(_excelSheet.Cells[5, 6], _excelSheet.Cells[5, 8]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
          _excelSheet.Cells[5, 6] = "DOLARES";

          Int32 _row = 6;
          
          _excelSheet.Cells[_row, 1] = "TIPO";
          _excelSheet.Cells[_row, 2] = "NUMERO";
          _excelSheet.Cells[_row, 3] = "DEBE";
          _excelSheet.Cells[_row, 4] = "HABER";
          _excelSheet.Cells[_row, 5] = "SALDO";
          _excelSheet.Cells[_row, 6] = "DEBE";
          _excelSheet.Cells[_row, 7] = "HABER";
          _excelSheet.Cells[_row, 8] = "SALDO";
          _excelSheet.Cells[_row, 9] = "FECHA";

          _excelSheet.get_Range(_excelSheet.Cells[1, 2], _excelSheet.Cells[1, 2]).EntireColumn.NumberFormat = "@";


          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 9]).Font.Bold = true;
          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 9]).Borders.Color = 000;
          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 9]).HorizontalAlignment = XlHAlign.xlHAlignCenter;

          int numerofila = 1;

          _row = _row + 2;

          foreach (DataRow fila in _dataTable.Rows)
          {
              //la primera fila es el encabezado
              if (numerofila == 1)
              {
                  _excelSheet.get_Range(_excelSheet.Cells[_row, 2], _excelSheet.Cells[_row, 3]).MergeCells = true;
              }
          }


      }

      
      public void exportToExcel(System.Data.DataTable _dataTable,String _empresa,String _sucursal,DateTime _dateinicio,DateTime _datefinal)
    {
      Int32 _row = 6;
      Int32 _col = 1;
      Boolean _state = false;
      Int32[] _positions = { 3, 4, 5, 6, 7,8};
      Double[] _parciales = { 0, 0, 0, 0, 0 ,0};
      Double[] _totales = { 0, 0, 0, 0, 0 ,0};

      String codigoPlanCuenta = "CODIGOPLANCUENTA";
      String ruc = "RUC";

      Application _excel = new Application();
      Workbook _excelBook = _excel.Workbooks.Add(XlSheetType.xlWorksheet);
      Worksheet _excelSheet = (Worksheet)_excel.ActiveSheet;

      _excelSheet.Visible = XlSheetVisibility.xlSheetVisible;
      _excelSheet.Name = "ReporteExcel";

      /*Start head*/
      _excelSheet.Cells[1, 1] = "EMPRESA";
      
      _excelSheet.get_Range(_excelSheet.Cells[1, 2], _excelSheet.Cells[1, 3]).MergeCells = true;
      _excelSheet.Cells[1, 2] = _empresa;
      _excelSheet.Cells[1, 7] = "FECHA";
      try
      {
          _excelSheet.get_Range(_excelSheet.Cells[1, 1]).Font.Bold = true;
          _excelSheet.get_Range(_excelSheet.Cells[1, 7]).Font.Bold = true;
      }
      catch (Exception e)
      {
          
          Console.WriteLine(e.Message);
      }
      
      _excelSheet.get_Range(_excelSheet.Cells[1, 8], _excelSheet.Cells[1, 9]).MergeCells = true;
      _excelSheet.Cells[1, 8] = DateTime.Now.ToShortDateString(); ;

      _excelSheet.Cells[2, 1] = "SUCURSAL";
      //_excelSheet.get_Range(_excelSheet.Cells[2, 2]).Font.Bold = true;
      //_excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 1]).Font.Bold = true;
      _excelSheet.get_Range(_excelSheet.Cells[2, 2], _excelSheet.Cells[2, 4]).MergeCells = true;
      _excelSheet.Cells[2, 2] = _sucursal;
      _excelSheet.Cells[2, 7] = "HORA";
      //_excelSheet.get_Range(_excelSheet.Cells[2, 7]).Font.Bold = true;
      _excelSheet.get_Range(_excelSheet.Cells[2, 8], _excelSheet.Cells[2, 9]).MergeCells = true;
      _excelSheet.Cells[2, 8] = DateTime.Now.ToShortTimeString();

      _excelSheet.get_Range(_excelSheet.Cells[3, 4], _excelSheet.Cells[3, 5]).MergeCells = true;
      //_excelSheet.get_Range(_excelSheet.Cells[3, 4], _excelSheet.Cells[3, 5]).Font.Bold = true;
      _excelSheet.get_Range(_excelSheet.Cells[3, 4], _excelSheet.Cells[3, 5]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
      _excelSheet.Cells[3, 4] = "ESTADOS DE CUENTA";

      _excelSheet.get_Range(_excelSheet.Cells[4, 4], _excelSheet.Cells[4, 5]).MergeCells = true;
      //_excelSheet.get_Range(_excelSheet.Cells[4, 4], _excelSheet.Cells[4, 5]).Font.Bold = false;
      _excelSheet.get_Range(_excelSheet.Cells[4, 4], _excelSheet.Cells[4, 5]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
      _excelSheet.Cells[4, 4] = "(" + _dateinicio.ToString("yyyy/MM/dd") + " - " + _datefinal.ToString("yyyy/MM/dd") + ")";
      //_excelSheet.get_Range(_excelSheet.Cells[4, 4]).Font.Bold = true;

      _excelSheet.get_Range(_excelSheet.Cells[5, 3], _excelSheet.Cells[5, 5]).MergeCells = true;
      _excelSheet.get_Range(_excelSheet.Cells[5, 3], _excelSheet.Cells[5, 5]).Borders.Color = 000;
      _excelSheet.get_Range(_excelSheet.Cells[5, 3], _excelSheet.Cells[5, 5]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
      _excelSheet.Cells[5, 3] = "SOLES";
      //_excelSheet.get_Range(_excelSheet.Cells[5, 3]).Font.Bold = true;
      _excelSheet.get_Range(_excelSheet.Cells[5, 6], _excelSheet.Cells[5, 8]).MergeCells = true;
      _excelSheet.get_Range(_excelSheet.Cells[5, 6], _excelSheet.Cells[5, 8]).Borders.Color = 000;
      _excelSheet.get_Range(_excelSheet.Cells[5, 6], _excelSheet.Cells[5, 8]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
      _excelSheet.Cells[5, 6] = "DOLARES";
      //_excelSheet.get_Range(_excelSheet.Cells[5, 6]).Font.Bold = true;

      /*foreach (DataColumn column in _dataTable.Columns)
      {
        if (column.ColumnName != "CodigoPlanCuenta" && column.ColumnName != "NombrePlanCuenta" && column.ColumnName != "Ruc" && column.ColumnName != "RazonSocial" && column.ColumnName != "Referencia" && column.ColumnName != "PlanCuentaId" && column.ColumnName != "PeriodoID" && column.ColumnName != "CodigoSubDiario" && column.ColumnName != "Comprobante" && column.ColumnName != "Codigo" && column.ColumnName != "NombreSubDiario") 
        {
          //_excelSheet.Cells[_row, _col] = column.ColumnName;
          _excelSheet.Cells[_row, 1] = "TIPO";
          _excelSheet.Cells[_row, 2] = "NUMERO";
          _excelSheet.Cells[_row, 3] = "DEBE";
          _excelSheet.Cells[_row, 4] = "HABER";
          _excelSheet.Cells[_row, 5] = "SALDO";
          _excelSheet.Cells[_row, 6] = "DEBE";
          _excelSheet.Cells[_row, 7] = "HABER";
          _excelSheet.Cells[_row, 8] = "SALDO";
          _excelSheet.Cells[_row, 9] = "FECHA";

          if (column.DataType == System.Type.GetType("System.String"))
          {
            _excelSheet.get_Range(_excelSheet.Cells[1, _col], _excelSheet.Cells[1, _col]).EntireColumn.NumberFormat = "@";
          }

          if (column.ColumnName == "DebeSoles") { _positions[0] = _col; }
          if (column.ColumnName == "HaberSoles") { _positions[1] = _col; }
          if (column.ColumnName == "SaldoSoles") { _positions[2] = _col; }
          if (column.ColumnName == "DebeDolares") { _positions[3] = _col; }
          if (column.ColumnName == "HaberDolares") { _positions[4] = _col; }
          if (column.ColumnName == "SaldoDolares") { _positions[5] = _col; }

          _col++;
        }
      }*/
      
      _excelSheet.Cells[_row, 1] = "TIPO";
      _excelSheet.Cells[_row, 2] = "NUMERO";
      _excelSheet.Cells[_row, 3] = "DEBE";
      _excelSheet.Cells[_row, 4] = "HABER";
      _excelSheet.Cells[_row, 5] = "SALDO";
      _excelSheet.Cells[_row, 6] = "DEBE";
      _excelSheet.Cells[_row, 7] = "HABER";
      _excelSheet.Cells[_row, 8] = "SALDO";
      _excelSheet.Cells[_row, 9] = "FECHA";
      //_excelSheet.Cells[_row, 10] = "CODIGO SUBDIARIO";
      //_excelSheet.Cells[_row, 11] = "SUBDIARIO";
      //_excelSheet.Cells[_row, 12] = "RAZON SOCIAL";
      //_excelSheet.Cells[_row, 13] = "RUC";
      
      

      _excelSheet.get_Range(_excelSheet.Cells[1, 2], _excelSheet.Cells[1, 2]).EntireColumn.NumberFormat = "@";


      //_excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row,9]).Font.Bold = true;
      _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row,9]).Borders.Color = 000;
      _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row,9]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
      /*End head*/

      _row=_row+2;
      foreach (System.Data.DataColumn col in _dataTable.Columns) col.ReadOnly = false;  
      foreach (DataRow dataRow in _dataTable.Rows)
      {
        _col = 1;

        if (codigoPlanCuenta != (String)dataRow["CodigoPlanCuenta"])
        {
          codigoPlanCuenta = (String)dataRow["CodigoPlanCuenta"];

          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 5]).Interior.ColorIndex = 15;
          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 5]).Borders.Color = 000;
          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 5]).Font.Bold = true;
          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 5]).MergeCells = true;
          _excelSheet.Cells[_row, 1] = (String)dataRow["NombrePlanCuenta"]; ;
          ruc = "RUC";
          _row = _row + 2;
        }
        dataRow["ruc"] = (dataRow["ruc"] is DBNull) ? "" : dataRow["ruc"];  
        if (ruc != (String)dataRow["ruc"])
        {
          ruc = (String)dataRow["ruc"];


          if (_state == true)
          {
            _excelSheet.Cells[_row, _positions[0]] = _parciales[0];
            _totales[0] += _parciales[0];
            _excelSheet.Cells[_row, _positions[1]] = _parciales[1];
            _totales[1] += _parciales[1];
            _excelSheet.Cells[_row, _positions[2]] = _parciales[2];
            _totales[2] += _parciales[2];
            _excelSheet.Cells[_row, _positions[3]] = _parciales[3];
            _totales[3] += _parciales[3];
            _excelSheet.Cells[_row, _positions[4]] = _parciales[4];
            _totales[4] += _parciales[4];
            _excelSheet.Cells[_row, _positions[5]] = _parciales[5];
            _totales[5] += _parciales[5];

            //_excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Interior.Color = 178178178;
            _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Borders.Color = 000;
            _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).HorizontalAlignment = XlHAlign.xlHAlignRight;

            _row = _row + 2;
          }

          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).Interior.ColorIndex = 24;
          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).Borders.Color = 777;
          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).EntireColumn.NumberFormat = "@";
          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 6]).MergeCells = true;
          //_excelSheet.Cells[_row, 1] = "RazonSocial";
          dataRow["RazonSocial"] = (dataRow["RazonSocial"] is DBNull) ? "" : dataRow["RazonSocial"];
          _excelSheet.Cells[_row, 1] = "Razon Social: " + (String)dataRow["RazonSocial"] + " Ruc: " + (String)dataRow["Ruc"];
          _row++;

          //_excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).Interior.ColorIndex = 24;
          //_excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).Borders.Color = 777;
          //_excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).EntireColumn.NumberFormat = "@";
          //_excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 4]).MergeCells = true;

          //_excelSheet.Cells[_row, 1] = (String)dataRow["Ruc"];
          //_excelSheet.Cells[_row, 6] = "Ruc";
          
          _row++;

          _parciales[0] = 0;
          _parciales[1] = 0;
          _parciales[2] = 0;
          _parciales[3] = 0;
          _parciales[4] = 0;
          _parciales[5] = 0;
        }
        else {
          _state = true;
        }

        if (ruc != "RUC") { _state = true; }

        _parciales[0] += Convert.ToDouble(dataRow["DebeSoles"]);
        _parciales[1] += Convert.ToDouble(dataRow["HaberSoles"]);
        _parciales[2] += Convert.ToDouble(dataRow["SaldoSoles"]);
        _parciales[3] += Convert.ToDouble(dataRow["DebeDolares"]);
        _parciales[4] += Convert.ToDouble(dataRow["HaberDolares"]);
        _parciales[5] += Convert.ToDouble(dataRow["SaldoDolares"]);


        /*foreach (DataColumn column in _dataTable.Columns)
        {
          if (column.ColumnName != "CodigoPlanCuenta" && column.ColumnName != "NombrePlanCuenta" && column.ColumnName != "Ruc" && column.ColumnName != "RazonSocial" && column.ColumnName != "Referencia" && column.ColumnName != "PlanCuentaId" && column.ColumnName != "PeriodoID" && column.ColumnName != "CodigoSubDiario" && column.ColumnName != "Comprobante" && column.ColumnName != "Codigo" && column.ColumnName != "NombreSubDiario") 
          {
            _excelSheet.Cells[_row, _col] = dataRow[column];
            _excelSheet.get_Range(_excelSheet.Cells[_row, _col], _excelSheet.Cells[_row, _col]).HorizontalAlignment = XlHAlign.xlHAlignRight;
            _col++;
          }
        }*/
                 
        _excelSheet.Cells[_row, 1] = dataRow["CodigoSunat"];
        _excelSheet.Cells[_row, 2] = dataRow["NumeroDocumento"];
        _excelSheet.Cells[_row, 3] = dataRow["DebeSoles"];
        _excelSheet.Cells[_row, 4] = dataRow["HaberSoles"];
        _excelSheet.Cells[_row, 5] = dataRow["SaldoSoles"];
        _excelSheet.Cells[_row, 6] = dataRow["DebeDolares"];
        _excelSheet.Cells[_row, 7] = dataRow["HaberDolares"];
        _excelSheet.Cells[_row, 8] = dataRow["SaldoDolares"];
        //_excelSheet.Cells[_row, 8] = 999;
        _excelSheet.Cells[_row, 9] = dataRow["Dia"];
        //_excelSheet.Cells[_row, 10] = dataRow["CodigoSubDiario"];
        //_excelSheet.Cells[_row, 11] = dataRow["NombreSubDiario"];
        //_excelSheet.Cells[_row, 12] = dataRow["RazonSocial"];
        //_excelSheet.Cells[_row, 13] = dataRow["ruc"];
        
        _excelSheet.get_Range(_excelSheet.Cells[_row, 3], _excelSheet.Cells[_row, 13]).HorizontalAlignment = XlHAlign.xlHAlignRight;

        _row++;
      }
      _excelSheet.Cells[_row, _positions[0]] = _parciales[0];
      _totales[0] += _parciales[0];
      _excelSheet.Cells[_row, _positions[1]] = _parciales[1];
      _totales[1] += _parciales[1];
      _excelSheet.Cells[_row, _positions[2]] = _parciales[2];
      _totales[2] += _parciales[2];
      _excelSheet.Cells[_row, _positions[3]] = _parciales[3];
      _totales[3] += _parciales[3];
      _excelSheet.Cells[_row, _positions[4]] = _parciales[4];
      _totales[4] += _parciales[4];
      _excelSheet.Cells[_row, _positions[5]] = _parciales[5];
      _totales[5] += _parciales[5];

      //_excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Interior.Color = 178178178;
      _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Borders.Color = 000;
      _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).HorizontalAlignment = XlHAlign.xlHAlignRight;

      _row = _row + 2;

      _excelSheet.Cells[_row, _positions[0]] = _totales[0];
      _excelSheet.Cells[_row, _positions[1]] = _totales[1];
      _excelSheet.Cells[_row, _positions[2]] = _totales[2];
      _excelSheet.Cells[_row, _positions[3]] = _totales[3];
      _excelSheet.Cells[_row, _positions[4]] = _totales[4];
      _excelSheet.Cells[_row, _positions[5]] = _totales[5];

      _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 2]).MergeCells = true;
      _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 2]).Interior.Color = 178178178;
      _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 2]).Borders.Color = 000;
      _excelSheet.Cells[_row, 1] = "TOTAL GENERAL";

      _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Font.Bold = true;
      _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Borders.Color = 000;
      _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Interior.Color = 178178178;
      _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).HorizontalAlignment = XlHAlign.xlHAlignRight;

      _excel.Visible = true;
      _excel.Quit();
    }

      public void exportToExcelHistorico(System.Data.DataTable _dataTable, String _empresa, String _sucursal, DateTime _dateinicio, DateTime _datefinal)
      {
          
      }
      public void exportToExcelDetallado(System.Data.DataTable _dataTable, String _empresa, String _sucursal, DateTime _dateinicio, DateTime _datefinal)
      {
          Int32 _row = 6;
          Int32 _col = 1;
          Boolean _state = false;
          Int32[] _positions = { 10, 11, 12, 13, 14, 15 };
          Double[] _parciales = { 0, 0, 0, 0, 0, 0 };
          Double[] _totales = { 0, 0, 0, 0, 0, 0 };

          String codigoPlanCuenta = "CODIGOPLANCUENTA";
          String ruc = "RUC";

          Application _excel = new Application();
          Workbook _excelBook = _excel.Workbooks.Add(XlSheetType.xlWorksheet);
          Worksheet _excelSheet = (Worksheet)_excel.ActiveSheet;

          _excelSheet.Visible = XlSheetVisibility.xlSheetVisible;
          _excelSheet.Name = "ReporteExcel";

          /*Start head*/
          _excelSheet.Cells[1, 1] = "EMPRESA";

          _excelSheet.get_Range(_excelSheet.Cells[1, 2], _excelSheet.Cells[1, 3]).MergeCells = true;
          _excelSheet.Cells[1, 2] = _empresa;
          _excelSheet.Cells[1, 7] = "FECHA";
          try
          {
              _excelSheet.get_Range(_excelSheet.Cells[1, 1]).Font.Bold = true;
              _excelSheet.get_Range(_excelSheet.Cells[1, 14]).Font.Bold = true;
          }
          catch (Exception e)
          {

              Console.WriteLine(e.Message);
          }

          _excelSheet.get_Range(_excelSheet.Cells[1, 15], _excelSheet.Cells[1, 16]).MergeCells = true;
          _excelSheet.Cells[1, 8] = DateTime.Now.ToShortDateString(); ;

          _excelSheet.Cells[2, 1] = "SUCURSAL";
          _excelSheet.get_Range(_excelSheet.Cells[2, 2], _excelSheet.Cells[2, 4]).MergeCells = true;
          _excelSheet.Cells[2, 2] = _sucursal;
          _excelSheet.Cells[2, 7] = "HORA";
          _excelSheet.get_Range(_excelSheet.Cells[2, 8], _excelSheet.Cells[2, 9]).MergeCells = true;
          _excelSheet.Cells[2, 8] = DateTime.Now.ToShortTimeString();

          _excelSheet.get_Range(_excelSheet.Cells[3, 4], _excelSheet.Cells[3, 5]).MergeCells = true;
          _excelSheet.get_Range(_excelSheet.Cells[3, 4], _excelSheet.Cells[3, 5]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
          _excelSheet.Cells[3, 4] = "ESTADOS DE CUENTA";

          _excelSheet.get_Range(_excelSheet.Cells[4, 4], _excelSheet.Cells[4, 5]).MergeCells = true;
          _excelSheet.get_Range(_excelSheet.Cells[4, 4], _excelSheet.Cells[4, 5]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
          _excelSheet.Cells[4, 4] = "(" + _dateinicio.ToString("yyyy/MM/dd") + " - " + _datefinal.ToString("yyyy/MM/dd") + ")";
          _excelSheet.get_Range(_excelSheet.Cells[5, 10], _excelSheet.Cells[5, 12]).MergeCells = true;
          _excelSheet.get_Range(_excelSheet.Cells[5, 10], _excelSheet.Cells[5, 12]).Borders.Color = 000;
          _excelSheet.get_Range(_excelSheet.Cells[5, 10], _excelSheet.Cells[5, 12]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
          _excelSheet.Cells[5, 10] = "SOLES";
          _excelSheet.get_Range(_excelSheet.Cells[5, 13], _excelSheet.Cells[5, 15]).MergeCells = true;
          _excelSheet.get_Range(_excelSheet.Cells[5, 13], _excelSheet.Cells[5, 15]).Borders.Color = 000;
          _excelSheet.get_Range(_excelSheet.Cells[5, 13], _excelSheet.Cells[5, 15]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
          _excelSheet.Cells[5, 13] = "DOLARES";

          _excelSheet.Cells[_row, 1] = "CODIGO PLAN DE CUENTA";
          _excelSheet.Cells[_row, 2] = "PLAN DE CUENTA";
          _excelSheet.Cells[_row, 3] = "RAZON SOCIAL";
          _excelSheet.Cells[_row, 4] = "RUC";
          _excelSheet.Cells[_row, 5] = "CODIGO SUBDIARIO";
          _excelSheet.Cells[_row, 6] = "COMPROBANTE";
          _excelSheet.Cells[_row, 7] = "REFERENCIA";
          _excelSheet.Cells[_row, 8] = "TIPO";
          _excelSheet.Cells[_row, 9] = "NUMERO";
          _excelSheet.Cells[_row, 10] = "DEBE";
          _excelSheet.Cells[_row, 11] = "HABER";
          _excelSheet.Cells[_row, 12] = "SALDO";
          _excelSheet.Cells[_row, 13] = "DEBE";
          _excelSheet.Cells[_row, 14] = "HABER";
          _excelSheet.Cells[_row, 15] = "SALDO";
          _excelSheet.Cells[_row, 16] = "FECHA";
          _excelSheet.Cells[_row, 17] = "SUBDIARIO";
          _excelSheet.Cells[_row, 18] = "TIPO CAMBIO";

          _excelSheet.get_Range(_excelSheet.Cells[1, 2], _excelSheet.Cells[1, 2]).EntireColumn.NumberFormat = "@";

          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 18]).Borders.Color = 000;
          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 18]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
          /*End head*/

          _row = _row + 2;
          foreach (System.Data.DataColumn col in _dataTable.Columns) col.ReadOnly = false;
          foreach (DataRow dataRow in _dataTable.Rows)
          {
              _col = 1;

              if (codigoPlanCuenta != (String)dataRow["CodigoPlanCuenta"])
              {
                  codigoPlanCuenta = (String)dataRow["CodigoPlanCuenta"];

                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 5]).Interior.ColorIndex = 15;
                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 5]).Borders.Color = 000;
                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 5]).Font.Bold = true;
                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 5]).MergeCells = true;
                  _excelSheet.Cells[_row, 1] = (String)dataRow["NombrePlanCuenta"]; ;
                  ruc = "RUC";
                  _row = _row + 2;
              }
              dataRow["ruc"] = (dataRow["ruc"] is DBNull) ? "" : dataRow["ruc"];
              if (ruc != (String)dataRow["ruc"])
              {
                  ruc = (String)dataRow["ruc"];


                  if (_state == true)
                  {
                      _excelSheet.Cells[_row, _positions[0]] = _parciales[0];
                      _totales[0] += _parciales[0];
                      _excelSheet.Cells[_row, _positions[1]] = _parciales[1];
                      _totales[1] += _parciales[1];
                      _excelSheet.Cells[_row, _positions[2]] = _parciales[2];
                      _totales[2] += _parciales[2];
                      _excelSheet.Cells[_row, _positions[3]] = _parciales[3];
                      _totales[3] += _parciales[3];
                      _excelSheet.Cells[_row, _positions[4]] = _parciales[4];
                      _totales[4] += _parciales[4];
                      _excelSheet.Cells[_row, _positions[5]] = _parciales[5];
                      _totales[5] += _parciales[5];

                      _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Borders.Color = 000;
                      _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).HorizontalAlignment = XlHAlign.xlHAlignRight;

                      _row = _row + 2;
                  }

                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).Interior.ColorIndex = 24;
                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).Borders.Color = 000;
                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).EntireColumn.NumberFormat = "@";
                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 4]).MergeCells = true;

                  dataRow["RazonSocial"] = (dataRow["RazonSocial"] is DBNull) ? "" : dataRow["RazonSocial"];
                  _excelSheet.Cells[_row, 1] = (String)dataRow["RazonSocial"];
                  _row++;

                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).Interior.ColorIndex = 24;
                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).Borders.Color = 000;
                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 8]).EntireColumn.NumberFormat = "@";
                  _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 4]).MergeCells = true;

                  _excelSheet.Cells[_row, 1] = (String)dataRow["Ruc"];

                  _row++;

                  _parciales[0] = 0;
                  _parciales[1] = 0;
                  _parciales[2] = 0;
                  _parciales[3] = 0;
                  _parciales[4] = 0;
                  _parciales[5] = 0;
              }
              else
              {
                  _state = true;
              }

              if (ruc != "RUC") { _state = true; }

              _parciales[0] += Convert.ToDouble(dataRow["DebeSoles"]);
              _parciales[1] += Convert.ToDouble(dataRow["HaberSoles"]);
              _parciales[2] += Convert.ToDouble(dataRow["SaldoSoles"]);
              _parciales[3] += Convert.ToDouble(dataRow["DebeDolares"]);
              _parciales[4] += Convert.ToDouble(dataRow["HaberDolares"]);
              _parciales[5] += Convert.ToDouble(dataRow["SaldoDolares"]);

              _excelSheet.Cells[_row, 1] = dataRow["CodigoPlanCuenta"];
              _excelSheet.Cells[_row, 2] = dataRow["NombrePlanCuenta"];
              _excelSheet.Cells[_row, 3] = (String)dataRow["RazonSocial"].ToString().Trim();
              _excelSheet.Cells[_row, 4] = dataRow["ruc"];
              _excelSheet.Cells[_row, 5] = dataRow["CodigoSubDiario"];
              _excelSheet.Cells[_row, 6] = dataRow["Comprobante"];
              _excelSheet.Cells[_row, 7] = dataRow["Referencia"];
              _excelSheet.Cells[_row, 8] = dataRow["CodigoSunat"];
              _excelSheet.Cells[_row, 9] = dataRow["NumeroDocumento"];
              _excelSheet.Cells[_row, 10] = dataRow["DebeSoles"];
              _excelSheet.Cells[_row, 11] = dataRow["HaberSoles"];
              _excelSheet.Cells[_row, 12] = dataRow["SaldoSoles"];
              _excelSheet.Cells[_row, 13] = dataRow["DebeDolares"];
              _excelSheet.Cells[_row, 14] = dataRow["HaberDolares"];
              _excelSheet.Cells[_row, 15] = dataRow["SaldoDolares"];
              _excelSheet.Cells[_row, 16] = dataRow["Dia"];
              _excelSheet.Cells[_row, 17] = dataRow["NombreSubDiario"];
              _excelSheet.Cells[_row, 18] = dataRow["TipoCambio"];
              _excelSheet.get_Range(_excelSheet.Cells[_row, 3], _excelSheet.Cells[_row, 18]).HorizontalAlignment = XlHAlign.xlHAlignRight;

              _row++;
          }
          _excelSheet.Cells[_row, _positions[0]] = _parciales[0];
          _totales[0] += _parciales[0];
          _excelSheet.Cells[_row, _positions[1]] = _parciales[1];
          _totales[1] += _parciales[1];
          _excelSheet.Cells[_row, _positions[2]] = _parciales[2];
          _totales[2] += _parciales[2];
          _excelSheet.Cells[_row, _positions[3]] = _parciales[3];
          _totales[3] += _parciales[3];
          _excelSheet.Cells[_row, _positions[4]] = _parciales[4];
          _totales[4] += _parciales[4];
          _excelSheet.Cells[_row, _positions[5]] = _parciales[5];
          _totales[5] += _parciales[5];

          _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Borders.Color = 000;
          _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).HorizontalAlignment = XlHAlign.xlHAlignRight;

          _row = _row + 2;

          _excelSheet.Cells[_row, _positions[0]] = _totales[0];
          _excelSheet.Cells[_row, _positions[1]] = _totales[1];
          _excelSheet.Cells[_row, _positions[2]] = _totales[2];
          _excelSheet.Cells[_row, _positions[3]] = _totales[3];
          _excelSheet.Cells[_row, _positions[4]] = _totales[4];
          _excelSheet.Cells[_row, _positions[5]] = _totales[5];

          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 2]).MergeCells = true;
          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 2]).Interior.Color = 178178178;
          _excelSheet.get_Range(_excelSheet.Cells[_row, 1], _excelSheet.Cells[_row, 2]).Borders.Color = 000;
          _excelSheet.Cells[_row, 1] = "TOTAL GENERAL";

          _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Font.Bold = true;
          _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Borders.Color = 000;
          _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).Interior.Color = 178178178;
          _excelSheet.get_Range(_excelSheet.Cells[_row, _positions[0]], _excelSheet.Cells[_row, _positions[5]]).HorizontalAlignment = XlHAlign.xlHAlignRight;

          _excel.Visible = true;
          _excel.Quit();
      }
  }
}
