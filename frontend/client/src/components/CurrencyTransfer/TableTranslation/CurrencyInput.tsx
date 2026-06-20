import styles from './CurrencyInput.module.scss'
import line from '../../../assets/line.png'
import polygon from '../../../assets/polygon.png'

type CurrencyInputProps = {
    value: string;
    currency: string;
}

export const CurrencyInput = ({ value, currency }: CurrencyInputProps) => {
    return (
        <div className={styles.rowTable}>
            <div className={styles.data}>
                <span>{value}</span>
                <img src={line} alt="Линия" />
                <span>{currency}</span>
            </div>
            <button className={styles.arrow}>
                <img src={polygon} alt="Стрелка" />
            </button>
        </div>
    );
};