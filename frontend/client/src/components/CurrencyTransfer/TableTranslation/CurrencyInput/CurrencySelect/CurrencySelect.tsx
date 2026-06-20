import { currencies } from '../../../../../mocks/currencyMocks';
import styles from './CurrencySelect.module.scss';

type CurrencySelectProps = {
  selectedCurrency: string;
  onSelect: (currency: string) => void;
};

export const CurrencySelect = ({ selectedCurrency, onSelect }: CurrencySelectProps) => {
  const handleChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    onSelect(e.target.value);
  };

  return (
    <select value={selectedCurrency} onChange={handleChange} className={styles.list} data-testid={'currency-select'}>
      {currencies.map((currency) => (
        <option value={currency.code} data-testid={`currency-option-${currency.code}`}>
          {currency.code}
        </option>
      ))}
    </select>
  );
};
