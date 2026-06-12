import type { InformationCurrency } from '../../../models/CurrencyInfo';
import styles from './CurrencyDescription.module.scss';

export const CurrencyDescription = ({ title, description }: InformationCurrency) => {
  return (
    <div>
      <p className={styles.header}>{title}</p>
      <span className={styles.text}>{description}</span>
    </div>
  );
};
