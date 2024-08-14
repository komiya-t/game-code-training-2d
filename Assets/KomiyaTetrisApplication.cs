// 1. UnityEngineをUsingしてはならない
// 2. 他の.csを足さずこのファイルのみで完結させること
public class KomiyaTetrisApplication : UserApplication
{
	struct Vec
    {
		public int x;
		public int y;

		public Vec(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	struct Mino
    {
		public int size;
		public int[] data;
		public Vec pos;
    }

	Mino[] minos =
	{
		new Mino // S
		{
			size = 3,
			data = new[] {
				0, 0, 0,
				1, 1, 0,
				0, 1, 1
			},
		},
		new Mino // I
        {
			size = 4,
			data = new[]
            {
				0, 0, 0, 0,
				1, 1, 1, 1,
				0, 0, 0, 0,
				0, 0, 0, 0,
            },
        },
	};


	private IMachine machine;

	// 毎フレーム(=1/60秒間隔で)呼ばれる
	public override void Update(IMachine machine)
	{
		this.machine = machine;

		machine.SetResolution(10, 20);


        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                machine.Draw(x, y, 31, 31, 31);
            }
        }

		var s = minos[0];
		s.pos = new Vec(5, 17);
		DrawMino(s);

		var i = minos[1];
		i.pos = new Vec(5, 10);
		DrawMino(i);
    }

	void Draw(Vec pos)
    {
		machine.Draw(pos.x, pos.y, 255, 0, 0);
    }

	void Draw(Vec startPos, int width, int[] data)
    {
		for (int idx = 0; idx < data.Length; idx++)
        {
			int x = startPos.x + idx % width;
			int y = startPos.y + idx / width;

			if (data[idx] != 0)
            {
				machine.Draw(x, y, 255, 0, 0);
            }
        }
    }

	void DrawMino(Mino mino)
	{
		var startPos = mino.pos;
		int sizeHalf = mino.size / 2;
		startPos.x -= sizeHalf;
		startPos.y -= sizeHalf;

		Draw(startPos, mino.size, mino.data);
	}
}
