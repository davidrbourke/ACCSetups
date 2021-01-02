using ACCSetups.Models.Enums;

namespace ACCSetups.Configurations
{
    public class ConfigurationTypesFactory
    {
        public static Configurations.IConfigurationType GetConfigurationType(Models.AccSetup.BaseSetup[] setups, ConfigurationType configurationType)
        {
            switch (configurationType)
            {
                case ConfigurationType.REDUCE_UNDERSTEER:
                    return new Configurations.ReduceUndersteer(setups[0]);
                case ConfigurationType.BLEND_SAFE_AND_AGGRESSIVE:
                    return new Configurations.BlendSafeAndAggressive(setups[0], setups[1]);
            }

            return null;
        }
    }
}
