import java.awt.Color;
import java.awt.Graphics;

public class Point {
	private int x;
    private int y;
	private static final int WIDTH = 20;
	private static final int HEIGHT = 20;
	
	public Point(Point p){
        this(p.x, p.y);
	}
	
	public Point(int x, int y){
		this.setX(x);
		this.setY(y);
	}	
		
	public int getX() {
        return this.x;
	}
	public void setX(int x) {
		this.x = x;
	}
	public int getY() {
        return this.y;
	}
	public void setY(int y) {
        this.y = y;
	}
	
	public void drawSquareFromPoint(Graphics g, Color color) {
		g.setColor(Color.BLACK);
		g.fillRect(x, y, WIDTH, HEIGHT);
		g.setColor(color);
		g.fillRect(x +1, y +1, WIDTH -2, HEIGHT -2);
	}
	
	public String toString() {
        return "[x=" + this.x + ",y=" + this.y + "]";
	}
	
	public boolean equals(Object nextSnakePosition) {
        if (nextSnakePosition instanceof Point) {
            Point to4ka = (Point)nextSnakePosition;
            return (this.x == to4ka.x) && (this.y == to4ka.y);
        }

        return false;
    }
}
