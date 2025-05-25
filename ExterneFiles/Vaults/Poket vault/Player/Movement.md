Das player Movement unterscheidet sich in zwei Arten:

ToPoint
Der Spieler gewegt sich zu der Touch position. Normalerweise nur auf der X Achse. Kann aber auch auf der Y achse folgen, z.b als Raumschiff

ToDirection:
Der Spieler bewegt sich durchgängig in eine Richtung (links, rechts), basierend auf der touch Position x. > 0 = rechts; < 0 = links;

Das movement kann über E_FreezeState in bestimmten oder allen achsen eingefroren werden.
