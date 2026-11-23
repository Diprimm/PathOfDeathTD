using UnityEngine;

public static class ArmorCalculator
{
    private const int K = 100;

    public static float CalculateDamage(float damage, DamageType damageType, float armor, ArmorType armorType)
    {
        //Armor effectivness at
        float at = ArmorEffectiveness(damageType, armorType);

        //armadura efectiva = armadura base * at;
        float effectiveArmor = armor * at;

        //dano final recivido = dano base * ( K / (armadura efectiva + K))
        float finalDamage = damage * (K / (effectiveArmor + K));

        return finalDamage;
    }

    public static float ArmorEffectiveness(DamageType damageType, ArmorType armorType)
    {
        if (damageType == DamageType.Void)
        {
            return 0;
        }

        if (armorType == ArmorType.None)
        {
            return 0;
        }

        if (armorType == ArmorType.Full)
        {
            return 0.5f;
        }

        //Casos especiales NO neutros
        switch (damageType)
        {
            case DamageType.Light:
                if (armorType == ArmorType.Heavy) return 1.5f;
                break;

            case DamageType.Heavy:
                if (armorType == ArmorType.Light) return 1.5f;
                break;

            case DamageType.Piercing:
                if (armorType == ArmorType.Light) return 0.5f;
                if (armorType == ArmorType.Heavy) return 1.25f;
                break;

            case DamageType.Blunt:
                if (armorType == ArmorType.Light) return 1.25f;
                if (armorType == ArmorType.Heavy) return 0.5f;
                break;

        }

        //Caso neutro
        return 1f;
    }
}
