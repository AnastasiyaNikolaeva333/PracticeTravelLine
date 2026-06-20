import { useState } from 'react';
import styles from './Input.module.scss';

type InputProps = {
  value: number;
  onAmountChange: (amount: number) => void;
};

export const Input = ({ value, onAmountChange }: InputProps) => {
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
      size={localValue.length || 1}
      onChange={handleChange}
      className={styles.amountInput}
      data-testid={'from-currency-input'}
    />
  );
};
