import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

/***
 * Base class for creating, drawing and find the position of an apple
 */
public class Apple {
	public static Random random;
	private Point applePosition;
	private Color appleColor;

	public Apple(Snake s) {
		applePosition = createApple(s);
		appleColor = Color.RED;
	}
	
	private Point createApple(Snake snake) {
		random = new Random();
		int x = random.nextInt(30) * 20;
		int y = random.nextInt(30) * 20;
		for (Point snakeElement : snake.body) {
			if (x == snakeElement.getX() || y == snakeElement.getY()) {
				return createApple(snake);
			}
		}

		return new Point(x, y);
	}
	
	public void drawApple(Graphics g){
        applePosition.drawSquareFromPoint(g, appleColor);
	}	
	
	public Point getApplePosition(){
        return applePosition;
	}
}
