import React, {useState} from 'react';

type IButtonOptions = 'UP' | 'DOWN';
export default function CounterBtnExe(){
  const [count, setCount] = useState<number>(0);

  const handleClick = (upOrDown :IButtonOptions) => {
    let newCount = count;
    switch(upOrDown){
      case 'UP':
        setCount(newCount++);
        break;
      case 'DOWN':
        setCount(newCount--);
          break;
      default: 
      break;
    }
  }

  return (
    <div>
      <h1>Count is {count}</h1>
      <br/>
      <button onClick={handleClick('UP')}></button>
    </div>
  )
}