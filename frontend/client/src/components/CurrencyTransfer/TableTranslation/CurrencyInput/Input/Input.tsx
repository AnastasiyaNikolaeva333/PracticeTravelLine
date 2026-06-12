import { useState } from 'react';
import styles from './Input.module.scss';

type InputProps = {
  value: number;
  onAmountChange: (amount: number) => void;
  testId: string;
};

export const Input = ({ value, onAmountChange, testId }: InputProps) => {
  const [localValue, setLocalValue] = useState(value.toString());

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const newValue = e.target.value;
    setLocalValue(newValue);

    const parsedValue = parseFloat(newValue);
    if (!isNaN(parsedValue)) {
      onAmountChange(parsedValue);
    }
  };

  return (
    <input
      type="text"
      value={localValue}
      size={localValue.length || 6}
      onChange={handleChange}
      className={styles.amountInput}
      data-testid={`${testId}`}
    />
  );
};
