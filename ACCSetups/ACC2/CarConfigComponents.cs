using System.Collections.Generic;

namespace ACCSetups.ACC2
{
    public class CarConfigComponents
    {
        public IList<CarConfigComponent> GetCarConfigComponents()
        {
            return new List<CarConfigComponent>
            {
                new CarConfigComponent
                {
                    JsonPath = "carName",
                    CarConfigDataType = CarConfigDataType.String
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.tyres.tyreCompound",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.tyres.tyrePressure",
                    CarConfigDataType = CarConfigDataType.IntegerArray
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.camber",
                    CarConfigDataType = CarConfigDataType.IntegerArray
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.toe",
                    CarConfigDataType = CarConfigDataType.IntegerArray
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.staticCamber",
                    CarConfigDataType = CarConfigDataType.FloatArray
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.toeOutLinear",
                    CarConfigDataType = CarConfigDataType.FloatArray
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.casterLF",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.casterRF",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.steerRatio",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.tC1",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.tC2",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.abs",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.eCUMap",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.fuelMix",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.telemetryLaps",
                    CarConfigDataType = CarConfigDataType.Integer
                }
            };
        }
    }
}
