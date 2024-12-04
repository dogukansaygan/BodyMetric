namespace BodyMetric
{
    public class BodyMetrics
    {
        public static float BasalMetabolicRate(bool Gender, byte Activity, float Weight, float Height, int Age)
        {
            float BMR = 0;

            if (Gender)
            {
                // Male
                BMR = 655.1f + (9.56f * Weight) + (1.85f * Height) - (4.68f * Age);
            }
            else
            {
                // Female
                BMR = 66.5f + (13.75f * Weight) + (5.03f * Height) - (6.75f * Age);
            }

            return BMR;
        }

        public static float DailyCalorieNeeds(bool Gender, byte Activity, float Weight, float Height, int Age)
        {
            float BMR = BasalMetabolicRate(Gender, Activity, Weight, Height, Age);

            switch (Activity)
            {
                case 1:
                    // Sedentary (No exercise)
                    BMR *= 1.2f;
                    break;
                case 2:
                    // Lightly active (Exercise 1-3 days per week)
                    BMR *= 1.375f;
                    break;
                case 3:
                    // Moderately active (Exercise 3-5 days per week)
                    BMR *= 1.55f;
                    break;
                case 4:
                    // Very active (Exercise 6-7 days per week)
                    BMR *= 1.725f;
                    break;
                case 5:
                    // Extremely active (Intense exercise every day)
                    BMR *= 1.9f;
                    break;
                default:
                    BMR *= 1.2f;
                    break;
            }

            return BMR;
        }

        public static float[] DailyMacroNeeds(int DailyCalorie)
        {
            float Carbohydrates, Protein, Fat;

            Carbohydrates = DailyCalorie * 0.45f;
            Protein = DailyCalorie * 0.3f;
            Fat = DailyCalorie * 0.25f;

            return new float[] { Carbohydrates, Protein, Fat };
        }

        public static double BodyMassIndex(int Weight, int Height)
        {
            double BMI = (Weight / Math.Pow(Height / 100.0, 2));

            return BMI;
        }

        public static int DailySodiumIntake()
        {
            return 5;
        }

        public static float DailyWaterIntake(float Weight)
        {
            // ML
            float Intake = Weight * 30;

            return Intake;
        }

        public static float CaloriesForDeficit(int DailyCalorie)
        {
            float DecifitCalorie = DailyCalorie - (DailyCalorie * 0.2f);

            return DecifitCalorie;
        }

        public static float CaloriesForBulk(int DailyCalorie)
        {
            float BulkCalorie = DailyCalorie + (DailyCalorie * 0.2f);

            return BulkCalorie;
        }

        public static double BodyFatPercentage(bool Gender, int Waist, int Neck, int Height)
        {
            double Bfp = 0;

            if (!Gender)
            {
                // Male
                Bfp = 495 / (1.0324 - 0.19077 * Math.Log10(Waist - Neck) + 0.15456 * Math.Log10(Height)) - 450;
            }
            else
            {
                // Female
                Bfp = 495 / (1.29579 - 0.35004 * Math.Log10(Waist + Neck) + 0.22100 * Math.Log10(Height)) - 450;
            }

            return Bfp;
        }

        public static float MuscleMass(int Weight, float BodyFat)
        {
            float MM = Weight - BodyFat;

            return MM;
        }
    }
}