import { useState } from 'react';
import { ButtonMore } from './ButtonMore/ButtonMore';
import { InformationAboutCurrencies } from './InformationAboutCurrencies/InformationAboutCurrencies';
import styles from './MoreAboutCurrencies.module.scss';
import type { InformationNeedCurrency } from '../../models/CurrencyInfo';

export const MoreAboutCurrencies = ({ currenciesData }: InformationNeedCurrency) => {
  const [isShowInfo, setIsShowInfo] = useState(false);

  const handleButtonClick = () => {
    setIsShowInfo(!isShowInfo);
  };

  return (
    <div className={styles.information}>
      <ButtonMore
        purchasedCurrencyCode={currenciesData[0].code}
        paymentCurrencyCode={currenciesData[1].code}
        isShowMore={isShowInfo}
        OnClick={handleButtonClick}
      />
      {isShowInfo && <InformationAboutCurrencies currenciesData={currenciesData} />}
    </div>
  );
};
