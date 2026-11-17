type SquareProps = {
  value: string;
};

function Square({ value }: SquareProps) {
    function handleClick(){
        console.log('clickled!');
    }

  return (
    <button 
        className="square"
        onClick ={handleClick}
    >
            {value}
    </button>
  );
}

export default Square;