public interface IDamageable
{
    float currentHealth { get; set; }
    float maxHealth { get; set; }
    void Damage(float damageValue);
    void Heal(float healValue);
    void Destroy();
}
