using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] float groundCheckRadius = 0.5f;
    [SerializeField] float groundCheckOffsetY = 0f;
    [SerializeField] float groundCheckDistance = 0.55f;

    [SerializeField] private LayerMask groundLayer;

    private BoolReactiveProperty _isPlayerLanded = new();
    public IReadOnlyReactiveProperty<bool> IsPlayerLanded => _isPlayerLanded;

    public bool CheckGroundStatus()
    {
        var hit = Physics2D.CircleCast((Vector2)transform.position + groundCheckOffsetY * Vector2.up, groundCheckRadius, Vector2.down, groundCheckDistance,groundLayer);
        if(hit.collider != null)
        {
            _isPlayerLanded.Value = true;
        }
        else
        {
            _isPlayerLanded.Value = false;
        }
        
        return hit.collider != null;
    }

    /// <summary>
    /// Raycast‚Ì‰Â‹‰»‚ğs‚¤(’Ç‰Á)
    /// </summary>
    void OnDrawGizmos()
    {
        //@CircleCast‚ÌƒŒƒC‚ğ‰Â‹‰»
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere((Vector2)transform.position + groundCheckOffsetY * Vector2.up + Vector2.down * groundCheckDistance, groundCheckRadius);
    }
}
