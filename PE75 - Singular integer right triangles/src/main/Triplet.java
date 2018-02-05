package main;

public class Triplet implements Comparable<Triplet> {

	private int a, b, c;

	public Triplet() {

	}

	public Triplet(int value1, int value2, int value3) {
		if (value1 >= value2) {
			if (value1 >= value3) {
				c = value1;
				if (value3 >= value2) {
					a = value2;
					b = value3;
				} else {
					a = value3;
					b = value2;
				}
			} else {
				c = value3;
				a = value2;
				b = value1;
			}
		} else {
			if (value1 <= value3) {
				a = value1;
				if (value3 >= value2) {
					b = value2;
					c = value3;
				} else {
					b = value3;
					c = value2;
				}
			} else {
				b = value1;
				a = value3;
				c = value2;
			}
			
		}
	}

	public Triplet getMultiple(int factor) {
		Triplet multiple = new Triplet();
		multiple.setA(factor * this.a);
		multiple.setB(factor * this.b);
		multiple.setC(factor * this.c);
		return multiple;
	}

	public int getSom() {
		return a + b + c;
	}

	protected void setA(int a) {
		this.a = a;
	}

	protected void setB(int b) {
		this.b = b;
	}

	protected void setC(int c) {
		this.c = c;
	}

	public int getA() {
		return a;
	}

	public int getB() {
		return b;
	}

	public int getC() {
		return c;
	}

	@Override
	public int compareTo(Triplet other) {
		if (this.a < other.a) {
			return -1;
		}
		if (this.a > other.a) {
			return 1;
		}

		if (this.b < other.b) {
			return -1;
		}
		if (this.b > other.b) {
			return 1;
		}

		if (this.c < other.c) {
			return -1;
		}
		if (this.c > other.c) {
			return 1;
		}

		return 0;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + a;
		result = prime * result + b;
		result = prime * result + c;
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Triplet other = (Triplet) obj;
		if (a != other.a)
			return false;
		if (b != other.b)
			return false;
		if (c != other.c)
			return false;
		return true;
	}
	
	@Override
	public String toString() {
		return String.format("(%d, %d, %d)", a, b, c);
	}

}
