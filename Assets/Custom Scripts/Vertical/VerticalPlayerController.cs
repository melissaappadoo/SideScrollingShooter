using UnityEngine;
using System.Collections;

public class VerticalPlayerController : MonoBehaviour 
{
	public GameObject projectile;
	public Transform firePoint1, firePoint2;
	public float maxSpeed;
	public float moveForce;
	public float fireRate;
	public float Damage;
	public LayerMask whatToHit;
	
	protected float horizVelocity;
	protected float vertVelocity;
	protected Rigidbody2D myRigidbody;
	
	protected bool firing;
	float currentTime = 0;	
	
	protected VerticalPushCamera cam;
	
	void Awake()
	{
		cam = Camera.main.GetComponent<VerticalPushCamera>();
		myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector2(transform.position.x, transform.position.y + (cam.speed * Time.deltaTime));
		
		if (Input.GetButtonDown("Fire1") && currentTime <= 0)
        {
			Shoot();
			currentTime = fireRate;
        }
		currentTime -= Time.deltaTime;
		
		horizVelocity = Input.GetAxis("Horizontal");
		vertVelocity = Input.GetAxis("Vertical");
	}

	void Shoot()
    {
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition1 = new Vector2(firePoint1.position.x, firePoint1.position.y);
		Vector2 firePointPosition2 = new Vector2(firePoint2.position.x, firePoint2.position.y);
		RaycastHit2D hit1 = Physics2D.Raycast(firePointPosition1, mousePosition - firePointPosition1, 100, whatToHit);
		RaycastHit2D hit2 = Physics2D.Raycast(firePointPosition2, mousePosition - firePointPosition2, 100, whatToHit);
		Effect();
		Debug.DrawLine(firePointPosition1, (mousePosition - firePointPosition1) * 100, Color.cyan);
		Debug.DrawLine(firePointPosition2, (mousePosition - firePointPosition2) * 100, Color.cyan);
		if (hit1.collider != null)
        {
			Debug.DrawLine(firePointPosition1, hit1.point, Color.red);
			Debug.DrawLine(firePointPosition1, hit2.point, Color.red);
		}
	}

	void Effect()
    {
		Instantiate(projectile, firePoint1.position, firePoint1.rotation);
		Instantiate(projectile, firePoint2.position, firePoint2.rotation);
    }
	
	void FixedUpdate()
	{
		myRigidbody.AddForce(horizVelocity * Vector2.right * moveForce);

		myRigidbody.AddForce(vertVelocity * Vector2.up * moveForce);

		if (Mathf.Abs(myRigidbody.velocity.sqrMagnitude) > maxSpeed * maxSpeed)
		{
			myRigidbody.velocity = Vector2.ClampMagnitude(myRigidbody.velocity, maxSpeed);
		}
	}
}
