type SquareProps = {
  value: string;
};

function Square({ value }: SquareProps) {
  return <button className="square">{value}</button>;
}

export default Square;