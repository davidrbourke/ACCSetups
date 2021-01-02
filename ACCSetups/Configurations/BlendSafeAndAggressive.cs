using ACCSetups.Models.AccSetup;
using System;
using System.Linq;

namespace ACCSetups.Configurations
{
    public class BlendSafeAndAggressive : IConfigurationType
    {
        private BaseSetup _safeSetup;
        private BaseSetup _aggressiveSetup;
        private decimal _ratio = 0.9m;

        public BlendSafeAndAggressive(BaseSetup safeSetup, BaseSetup aggressiveSetup)
        {
            if (safeSetup == null)
            {
                throw new ArgumentNullException(nameof(safeSetup));
            }

            if (aggressiveSetup == null)
            {
                throw new ArgumentNullException(nameof(aggressiveSetup));
            }

            _safeSetup = safeSetup;
            _aggressiveSetup = aggressiveSetup;
        }

        public BaseSetup GetUpdatedSetup()
        {
            UpdateTyres();
            UpdateCamber();
            UpdateToe();
            UpdateCaster();
            UpdateElectronics();
            UpdateMechanicalBalance();
            UpdateWheelRate();
            UpdateBumpStopRate();
            UpdateDampers();
            UpdateAeroBalancer();
            UpdateDriveTrain();

            return _safeSetup;
        }

        private void UpdateTyres()
        {
            var safeTyres = _safeSetup.BasicSetup.Tyres.TyrePressure;
            var aggressiveTyres = _aggressiveSetup.BasicSetup.Tyres.TyrePressure;

            _safeSetup.BasicSetup.Tyres.TyrePressure = safeTyres.Select((s, i) => Rnd(s, aggressiveTyres[i])).ToList();
        }

        private void UpdateCamber()
        {
            var safe = _safeSetup.BasicSetup.Alignment.Camber;
            var aggressive = _aggressiveSetup.BasicSetup.Alignment.Camber;

            _safeSetup.BasicSetup.Alignment.Camber = safe.Select((s, i) => Rnd(s, aggressive[i])).ToList();
        }

        private void UpdateToe()
        {
            var safe = _safeSetup.BasicSetup.Alignment.Toe;
            var aggressive = _aggressiveSetup.BasicSetup.Alignment.Toe;

            _safeSetup.BasicSetup.Alignment.Toe = safe.Select((s, i) => Rnd(s, aggressive[i])).ToList();
        }

        private void UpdateCaster()
        {
            var safe = _safeSetup.BasicSetup.Alignment;
            var aggressive = _aggressiveSetup.BasicSetup.Alignment;

            _safeSetup.BasicSetup.Alignment.CasterLF = Rnd(safe.CasterLF, aggressive.CasterLF);
            _safeSetup.BasicSetup.Alignment.CasterRF = Rnd(safe.CasterRF, aggressive.CasterRF);
        }

        private void UpdateElectronics()
        {
            var safe = _safeSetup.BasicSetup.Electronics;
            var aggressive = _aggressiveSetup.BasicSetup.Electronics;

            _safeSetup.BasicSetup.Electronics.TC1 = Rnd(safe.TC1, aggressive.TC1);
            _safeSetup.BasicSetup.Electronics.TC2 = Rnd(safe.TC2, aggressive.TC2);
            _safeSetup.BasicSetup.Electronics.Abs = Rnd(safe.Abs, aggressive.Abs);
            _safeSetup.BasicSetup.Electronics.ECUMap = Rnd(safe.ECUMap, aggressive.ECUMap);
        }

        private void UpdateMechanicalBalance()
        {
            var safe = _safeSetup.AdvancedSetup.MechanicalBalance;
            var aggressive = _aggressiveSetup.AdvancedSetup.MechanicalBalance;

            _safeSetup.AdvancedSetup.MechanicalBalance.ARBFront = Rnd(safe.ARBFront, aggressive.ARBFront);
            _safeSetup.AdvancedSetup.MechanicalBalance.ARBRear = Rnd(safe.ARBRear, aggressive.ARBRear);
            _safeSetup.AdvancedSetup.MechanicalBalance.BrakeTorque = Rnd(safe.BrakeTorque, aggressive.BrakeTorque);
            _safeSetup.AdvancedSetup.MechanicalBalance.BrakeBias= Rnd(safe.BrakeBias, aggressive.BrakeBias);
        }

        private void UpdateWheelRate()
        {
            var safe = _safeSetup.AdvancedSetup.MechanicalBalance.WheelRate;
            var aggressive = _aggressiveSetup.AdvancedSetup.MechanicalBalance.WheelRate;

            _safeSetup.AdvancedSetup.MechanicalBalance.WheelRate = safe.Select((s, i) => Rnd(s, aggressive[i])).ToList();
        }

        private void UpdateBumpStopRate()
        {
            var safeUp = _safeSetup.AdvancedSetup.MechanicalBalance.BumpStopRateUp;
            var aggressiveUp = _aggressiveSetup.AdvancedSetup.MechanicalBalance.BumpStopRateUp;
            var safeDown = _safeSetup.AdvancedSetup.MechanicalBalance.BumpStopRateDn;
            var aggressiveDown = _aggressiveSetup.AdvancedSetup.MechanicalBalance.BumpStopRateDn;
            var safeWindow = _safeSetup.AdvancedSetup.MechanicalBalance.BumpStopWindow;
            var aggressiveWindow = _aggressiveSetup.AdvancedSetup.MechanicalBalance.BumpStopWindow;


            _safeSetup.AdvancedSetup.MechanicalBalance.BumpStopRateUp = safeUp.Select((s, i) => Rnd(s, aggressiveUp[i])).ToList();
            _safeSetup.AdvancedSetup.MechanicalBalance.BumpStopRateDn = safeDown.Select((s, i) => Rnd(s, aggressiveDown[i])).ToList();
            _safeSetup.AdvancedSetup.MechanicalBalance.BumpStopWindow = safeWindow.Select((s, i) => Rnd(s, aggressiveWindow[i])).ToList();
        }

        private void UpdateDampers()
        {
            var safe = _safeSetup.AdvancedSetup.Dampers;
            var aggressive = _aggressiveSetup.AdvancedSetup.Dampers;

            _safeSetup.AdvancedSetup.Dampers.BumpSlow = safe.BumpSlow.Select((s, i) => Rnd(s, aggressive.BumpSlow[i])).ToList();
            _safeSetup.AdvancedSetup.Dampers.BumpFast = safe.BumpFast.Select((s, i) => Rnd(s, aggressive.BumpFast[i])).ToList();
            _safeSetup.AdvancedSetup.Dampers.ReboundSlow = safe.ReboundSlow.Select((s, i) => Rnd(s, aggressive.ReboundSlow[i])).ToList();
            _safeSetup.AdvancedSetup.Dampers.ReboundFast = safe.ReboundFast.Select((s, i) => Rnd(s, aggressive.ReboundFast[i])).ToList();
        }

        private void UpdateAeroBalancer()
        {
            var safe = _safeSetup.AdvancedSetup.AeroBalance;
            var aggressive = _aggressiveSetup.AdvancedSetup.AeroBalance;

            _safeSetup.AdvancedSetup.AeroBalance.RideHeight = safe.RideHeight.Select((s, i) => Rnd(s, aggressive.RideHeight[i])).ToList();
            _safeSetup.AdvancedSetup.AeroBalance.BrakeDuct= safe.BrakeDuct.Select((s, i) => Rnd(s, aggressive.BrakeDuct[i])).ToList();
            _safeSetup.AdvancedSetup.AeroBalance.Splitter = Rnd(safe.Splitter, aggressive.Splitter);
            _safeSetup.AdvancedSetup.AeroBalance.RearWing = Rnd(safe.RearWing, aggressive.RearWing);
        }

        private void UpdateDriveTrain()
        {
            var safe = _safeSetup.AdvancedSetup.Drivetrain;
            var aggressive = _aggressiveSetup.AdvancedSetup.Drivetrain;
            _safeSetup.AdvancedSetup.Drivetrain.Preload = Rnd(safe.Preload, aggressive.Preload);
        }

        private int Rnd(int valOne, int valTwo)
        {
            return (int)Math.Round(((valOne * _ratio) + valTwo) / 2.0m, 0, MidpointRounding.AwayFromZero);
        }
    }
}
