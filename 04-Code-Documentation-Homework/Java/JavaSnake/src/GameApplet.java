import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

/***
 * Main class for our game
 */
@SuppressWarnings("serial")
public class GameApplet extends Applet {
	private Game game;
	KeyHandler keyHandler;
	
	public void init(){
		game = new Game();
		game.setPreferredSize(new Dimension(800, 650));
		game.setVisible(true);
		game.setFocusable(true);
		this.add(game);
		this.setVisible(true);
		this.setSize(new Dimension(800, 650));
		keyHandler = new KeyHandler(game);
	}
	
	public void paint(Graphics g){
		this.setSize(new Dimension(800, 650));
	}

}
