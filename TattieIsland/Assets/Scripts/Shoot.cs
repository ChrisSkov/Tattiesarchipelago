using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [Header("Scriptable Objects")]
    public PlayerStats stats;
    public WeaponObj weapon;
    [SerializeField] GameObject bulletSocket = null;
    [SerializeField] GameObject shellHolder = null;
    GameObject[] shotgunShells;
    AudioSource source;
    public bool canShoot = true;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        shotgunShells = GameObject.FindGameObjectsWithTag("ShotgunShell");
        weapon.maxAmmo = shotgunShells.Length;
        weapon.currentAmmo = weapon.maxAmmo;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.currentlyEquippedWeapon == 1 && anim.GetBool("canShoot"))
        {
            FireShot();
            Reload();
            shellHolder.SetActive(true);
        }
        else
        {
            shellHolder.SetActive(false);
        }

    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("reload");
            foreach (GameObject shell in shotgunShells)
            {
                shell.SetActive(true);
            }
        }
    }

    private void FireShot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && weapon.currentAmmo > 0 && canShoot)
        {
            anim.SetTrigger("shoot");
        }
    }

    // Reload Anim Event
    void ReloadGunAnim()
    {
        weapon.currentAmmo = weapon.maxAmmo;
        source.PlayOneShot(weapon.reloadSound);
    }

    void WeCanShoot()
    {
        canShoot = true;
    }

    void WeCannotShoot()
    {
        canShoot = false;
    }

    //anim event
    void PlayPelletParticles()
    {
        weapon.currentAmmo--;
        Instantiate(weapon.particles, bulletSocket.transform.position, bulletSocket.transform.rotation);
        source.PlayOneShot(weapon.attackSound);
        shotgunShells[weapon.maxAmmo - weapon.currentAmmo - 1].SetActive(false);
    }
}
