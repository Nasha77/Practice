public class Enemy
{
    public string enemyId { get; }
    public string enemyName { get; }
    public int enemyHealth { get; set; }  // Ensure this is settable
    public int enemyAtk { get; }
    public int enemySpeed { get; }
    public int enemyEXP { get; }

    public Enemy(string enemyId, string enemyName, int enemyHealth, int enemyAtk, int enemySpeed, int enemyEXP)
    {
        this.enemyId = enemyId;
        this.enemyName = enemyName;
        this.enemyHealth = enemyHealth;
        this.enemyAtk = enemyAtk;
        this.enemySpeed = enemySpeed;
        this.enemyEXP = enemyEXP;
    }
}


