# Context #

This is the project for the course "Artificial Intelligence" at [Instituto de Informática](http://www.inf.ufrgs.br/), [UFRGS](http://www.ufrgs.br/ufrgs/inicial), Brazil.

| **Course:** | INF01048 - Artificial Intelligence |
|:------------|:-----------------------------------|
| **Semester:** | 2011/2                             |
| **Professor:** | [Mara Abel](http://inf.ufrgs.br/index.php?option=com_content&view=article&id=98%3Amara-abel&catid=39%3Acorpo-docente&Itemid=81) |
| **Students:** | Éderson Vieira, John Gamboa, [Lucas Lersch](http://www.inf.ufrgs.br/~lslersch/) |

# Description #

The game King´s Run is similar to other board games for two players that is played in turns (like chess). The hexagonal board has size 5 and it is composed by 61 hexagonal cells. Each player is represented by a color and has 10 pieces (9 soldiers and 1 king). Each player begin in one of the sides of the boards. The goal is to capture the opponent´s king.

# Rules #
  1. The king does not participate in captures, but it can be captured.
  1. In order to capture the opponent´s piece, it is necessary to place 2 soldiers in adjacent cells (numerical advantage!). The capture must be intentional, meaning that a player must explicitly move a piece of his own to perform a capture.
  1. Soldiers can move in any direction and orientation, provided that they are not blocked by other pieces. The king´s movement is similar to the soldiers, with the exception that it can only advance one cell per turn. The player must move one and only one piece per turn, not being possible to refrain from playing.
  1. The player with white pieces starts the game.

|<img src='http://www.inf.ufrgs.br/~lslersch/lib/exe/fetch.php?media=kingsrun_4.png' height='384' width='384'><table><thead><th><img src='http://www.inf.ufrgs.br/~lslersch/lib/exe/fetch.php?media=kingsrun_5.png' height='384' width='384'> </th></thead><tbody>
<tr><td>Initial disposal of the pieces in the board.                                                                 </td><td>Situations where gray pieces could be captured.                                                               </td></tr>
<tr><td><img src='http://www.inf.ufrgs.br/~lslersch/lib/exe/fetch.php?media=kingsrun_6.png' height='384' width='384'></td><td><img src='http://www.inf.ufrgs.br/~lslersch/lib/exe/fetch.php?media=kingsrun_7.png' height='384' width='384'> </td></tr>
<tr><td>Safe move. The gray piece will not be captured. No intention.                                                </td><td>Possible moves for a piece.                                                                                   </td></tr></tbody></table>

<h1>Artificial Intelligence</h1>
The search depth of the MiniMax algorithm can be adjusted in the start screen. The deeper the search, the more possible future game configurations the AI will calculate. In other words, the deeper, the harder ;)<br>
<br>
<h1>Screenshots</h1>
<table><thead><th><img src='http://www.inf.ufrgs.br/~lslersch/lib/exe/fetch.php?media=kingsrun_1.png' height='256' width='256'></th><th><img src='http://www.inf.ufrgs.br/~lslersch/lib/exe/fetch.php?media=kingsrun_2.png' height='256' width='256'></th><th><img src='http://www.inf.ufrgs.br/~lslersch/lib/exe/fetch.php?media=kingsrun_3.png' height='256' width='256'></th></thead><tbody>
<tr><td>Menu scene.                                                                                                  </td><td>Early Game.                                                                                                  </td><td>Middle game.                                                                                                 </td></tr></tbody></table>

<h1>Links</h1>

Visual C# 2010 Express: <a href='http://www.microsoft.com/visualstudio/en-us/products/2010-editions/visual-csharp-express'>http://www.microsoft.com/visualstudio/en-us/products/2010-editions/visual-csharp-express</a>

Visual Studio 2010 SP1: <a href='http://www.microsoft.com/download/en/details.aspx?id=23691'>http://www.microsoft.com/download/en/details.aspx?id=23691</a>

XNA Game Studio 4.0: <a href='http://www.microsoft.com/en-us/download/details.aspx?id=23714'>http://www.microsoft.com/en-us/download/details.aspx?id=23714</a>

XNA Game Studio 4.0 Runtime: <a href='http://www.microsoft.com/en-us/download/details.aspx?id=20914'>http://www.microsoft.com/en-us/download/details.aspx?id=20914</a>