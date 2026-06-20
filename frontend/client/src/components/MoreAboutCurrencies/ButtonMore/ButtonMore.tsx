import { Button } from '../../Button/Button';
import styles from './ButtonMore.module.scss';

type ButtonMoreProps = {
  purchasedCurrencyCode: string;
  paymentCurrencyCode: string;
  isShowMore: boolean;
  OnClick: () => void;
};

export const ButtonMore = ({ purchasedCurrencyCode, paymentCurrencyCode, isShowMore, OnClick }: ButtonMoreProps) => {
  const currencies = `${purchasedCurrencyCode}/${paymentCurrencyCode}`;
  const testButton = isShowMore ? `${currencies}: about ↑` : `More about ${currencies}`;
  return (
    <div className={styles.container}>
      <div className={styles.line}></div>
      <div className={styles.button}>
        <Button text={testButton} additionalStyles={styles.button} onClick={OnClick} />
      </div>
    </div>
  );
};
