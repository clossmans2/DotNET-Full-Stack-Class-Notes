using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace Training
{
    public class MotorsDb
    {
        private readonly IConfiguration _configuration;
        
        public SqlDataAdapter MotorsDataAdapter { get; set; }

        public SqlConnection Connection { get; set; }

        public DataSet DB { get; set; }

        public DataTable Vehicles { get; set; }

        public MotorsDb(IConfiguration config)
        {
            _configuration = config;
            var connString = _configuration.GetConnectionString("DefaultConnection");
            
            var vmap = CreateDataTableMapping();
            Connection = new SqlConnection(connString);
            string getVehicles = "SELECT * FROM [Vehicle]";
            MotorsDataAdapter = new SqlDataAdapter(getVehicles, Connection);
            MotorsDataAdapter.TableMappings.Add(vmap);
            DB = new DataSet("SkillStormMotors");
            MotorsDataAdapter.FillSchema(DB, SchemaType.Mapped);
            MotorsDataAdapter.Fill(DB);
            Vehicles = DB.Tables["Vehicle"];
        }

        public DataTableMapping CreateDataTableMapping()
        {
            // ...
            // create mappings
            // ...
            DataColumnMapping[] vehicleColumns = {
                new DataColumnMapping("Id", "Id"),
                new DataColumnMapping("Body", "Body"),
                new DataColumnMapping("Model", "Model"),
                new DataColumnMapping("Color", "Color"),
                new DataColumnMapping("Mileage", "Mileage"),
                new DataColumnMapping("Make", "Make"),
                new DataColumnMapping("MSRP", "Price"),
                new DataColumnMapping("TrimLevel", "Trim"),
                new DataColumnMapping("ModelYear", "Year"),
                new DataColumnMapping("VIN", "VIN")
            };
            // Copy mappings to array
            DataTableMapping VehicleMapping =
                new DataTableMapping("Vehicle", "Vehicle", vehicleColumns);

            return VehicleMapping;
            
        }
    }
}
