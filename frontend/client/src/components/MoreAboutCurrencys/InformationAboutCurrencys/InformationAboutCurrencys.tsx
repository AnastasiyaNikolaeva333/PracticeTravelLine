import styles from './InformationAboutCurrencys.module.scss'
import { CurrencyDescription } from './CurrencyDescription';

type InformationAboutCurrencysProps = {
    currencies: Array<{
        id: number;
        title: string;
        description: string;
    }>;
}

export const InformationAboutCurrencys = (props: InformationAboutCurrencysProps) => {
    return (
        <div className={styles.infoContainer}>
            {props.currencies.map((currency) => (
                <CurrencyDescription
                    key={currency.id}
                    title={currency.title}
                    description={currency.description}
                />
            ))}
        </div>
    );
};