#pragma strict
 
import System.Collections.Generic;
 
public class Triangulator {
 
	private var m_points:List.<Vector2> = new List.<Vector2>();
 
	public function Triangulator(points:Vector2[]) {
		m_points = new List.<Vector2>(points);
	}
 
	public function Triangulate() {
		var indices:List.<int> = new List.<int>();
 
		var n:int = m_points.Count;
		if (n < 3)
			return indices.ToArray();
 
		var V:int[] = new int[n];
		if (Area() > 0) 
		{
			for (var v:int = 0; v < n; v++)
				V[v] = v;
		}
		else {
			for (v = 0; v < n; v++)
				V[v] = (n - 1) - v;
		}
 
		var nv:int = n;
		var count:int = 2 * nv;
		var m=0;
		for (v = nv - 1; nv > 2; ) 
		{
			if ((count--) <= 0)
				return indices.ToArray();
 
			var u:int = v;
			if (nv <= u)
				u = 0;
			v = u + 1;
			if (nv <= v)
				v = 0;
			var w:int = v + 1;
			if (nv <= w)
				w = 0;
 
			if (Snip(u, v, w, nv, V)) 
			{
				var a:int;
				var b:int;
				var c:int;
				var s:int;
				var t:int;
				a = V[u];
				b = V[v];
				c = V[w];
				indices.Add(a);
				indices.Add(b);
				indices.Add(c);
				m++;
				s = v;
				for (t = v + 1; t < nv; t++)
				{
					V[s] = V[t];
					s++;
				}
				nv--;
				count = 2 * nv;
			}
		}
 
		indices.Reverse();
		return indices.ToArray();
	}
 
	private function Area () {
		var n:int = m_points.Count;
		var A:float = 0.0f;
		var q:int=0;
		for (var p:int = n - 1; q < n; p = q++) {
			var pval:Vector2 = m_points[p];
			var qval:Vector2 = m_points[q];
			A += pval.x * qval.y - qval.x * pval.y;
		}
		return (A * 0.5);
	}
 
	private function Snip (u:int, v:int, w:int, n:int, V:int[]) {
		var p:int;
		var A:Vector2 = m_points[V[u]];
		var B:Vector2 = m_points[V[v]];
		var C:Vector2 = m_points[V[w]];
		if (Mathf.Epsilon > (((B.x - A.x) * (C.y - A.y)) - ((B.y - A.y) * (C.x - A.x))))
			return false;
		for (p = 0; p < n; p++) {
			if ((p == u) || (p == v) || (p == w))
				continue;
			var P:Vector2 = m_points[V[p]];
			if (InsideTriangle(A, B, C, P))
				return false;
		}
		return true;
	}
 
	private function InsideTriangle (A:Vector2, B:Vector2, C:Vector2, P:Vector2) {
		var ax:float;
		var ay:float;
		var bx:float;
		var by:float;
		var cx:float;
		var cy:float;
		var apx:float;
		var apy:float;
		var bpx:float;
		var bpy:float;
		var cpx:float;
		var cpy:float;
		var cCROSSap:float;
		var bCROSScp:float;
		var aCROSSbp:float;
 
		ax = C.x - B.x; ay = C.y - B.y;
		bx = A.x - C.x; by = A.y - C.y;
		cx = B.x - A.x; cy = B.y - A.y;
		apx = P.x - A.x; apy = P.y - A.y;
		bpx = P.x - B.x; bpy = P.y - B.y;
		cpx = P.x - C.x; cpy = P.y - C.y;
 
		aCROSSbp = ax * bpy - ay * bpx;
		cCROSSap = cx * apy - cy * apx;
		bCROSScp = bx * cpy - by * cpx;
 
		return ((aCROSSbp >= 0.0) && (bCROSScp >= 0.0) && (cCROSSap >= 0.0));
	}
}