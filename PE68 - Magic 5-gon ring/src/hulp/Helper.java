package hulp;

public class Helper {
	
	
	public static int[] sizeUp(int[] input) {
		int[] result = new int[input.length + 1];
		for (int i = 0; i < input.length; i++) {
			result[i + 1] = input[i];
		}
		return result;
	}
	
	public static int[] combineer(int[] set, int number) {
		set = sizeUp(set);
		set[0] = number;
		return set;
	}
	
	public static int[] removeNumber(int[] set, int index) {
		int[] result = new int[set.length - 1];
		for (int i = 0, currIndex = 0; i < set.length; i++) {
			if (i == index) {
				continue;
			}
			result[currIndex++] = set[i];
		}
		return result;
	}

}
